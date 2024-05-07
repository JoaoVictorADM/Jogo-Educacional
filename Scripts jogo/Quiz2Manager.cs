using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using TMPro;

public class Quiz2Manager : MonoBehaviour{

    private int pontuacaoRecuperada;
    
    public Image ImagemQuestaoAtualAntes;
    public Image ImagemQuestaoAtualDepois;
    public Sprite[] vetorImagensAntes;
    public Sprite[] vetorImagensDepois;
    public int[] respostaImagens;
    public Button[] botoesResposta;

    List<int> numerosGerados = new List<int>();
    System.Random random = new System.Random();
    List<int> respostasErradas = new List<int>();

    private bool estadoOpcoes = false;
    private int contadorQuestoes;
    private int idPergunta;
    private int acertos;
    private int questoes = 5;
    private int pontuacao1 = 0;
    private int respostaDada = 0;
    private int contador;
    private float mediaPontuacao;

    [SerializeField] private GameObject botoesQuiz;
    [SerializeField] private GameObject painelQuiz;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelPontuacao;
    [SerializeField] private Sprite spriteEstrelaPreenchida;
    [SerializeField] private TextMeshProUGUI  numeroQuestoes;
    [SerializeField] private TextMeshProUGUI  pontuacaoTela;
    [SerializeField] private TextMeshProUGUI  questaoAtual;
    [SerializeField] private Image[] vetorEstrelas;
    [SerializeField] private AudioSource fundoMusical;
    [SerializeField] private AudioSource dublagem;

    void Start(){

        AjustarResolucao();
        pontuacaoRecuperada = PlayerPrefs.GetInt("Pontuacao1", 0);
        UnityEngine.Debug.Log(pontuacaoRecuperada);
        contadorQuestoes = 1;
        proximaPergunta();
        
    }

    public void proximaPergunta(){
        
        contador = 4;

        questaoAtual.text = "QUESTÃO " + contadorQuestoes.ToString() + " /" + questoes.ToString();

        for(int i=0; i<botoesResposta.Length; i++){

            botoesResposta[i].image.color = Color.white;
            botoesResposta[i].interactable = true;

        }

        do{
            idPergunta = random.Next(0, respostaImagens.Length - 1);
        } while(numerosGerados.Contains(idPergunta));

        numerosGerados.Add(idPergunta);

        ImagemQuestaoAtualAntes.sprite = vetorImagensAntes[idPergunta];
        ImagemQuestaoAtualDepois.sprite = vetorImagensDepois[idPergunta];

    }

    public void verificarResposta(int resposta){
        
        respostaDada = resposta;

        if(resposta == respostaImagens[idPergunta]){

            StopAudio();

            for(int i=0; i<botoesResposta.Length; i++){

                configurarTransparencia(i);
                botoesResposta[i].interactable = false;

            }

            botoesResposta[resposta].image.color = Color.green;

            pontuacao1 += contador;
            contadorQuestoes++;
            respostasErradas.Clear();

            if(contadorQuestoes <= questoes)
                Invoke("proximaPergunta", 2.0f);
            else{

                mostrarPontuacao();

            }
                
            
        } else{

            for(int i = 0; i<botoesResposta.Length; i++)
                botoesResposta[i].interactable = false;

            botoesResposta[resposta].image.color = Color.red;
            respostasErradas.Add(resposta);
            Invoke("respostaErrada", 2.0f);

        }

   }

   public void respostaErrada(){

        contador--;

        configurarTransparencia(respostaDada);

        for(int i = 0; i<botoesResposta.Length; i++){

            if(!respostasErradas.Contains(i)){
                
                botoesResposta[i].interactable = true;

            }

        }
                

   }

    public void configurarTransparencia(int i){

        Color corBotao = botoesResposta[i].colors.normalColor;
        corBotao.a = 0.5f;
        botoesResposta[i].image.color = corBotao;

    }

    public void mostrarPontuacao(){

        mediaPontuacao = (float)pontuacao1 / (questoes*0.4f);

        painelQuiz.SetActive(false);
        painelPontuacao.SetActive(true);

        pontuacaoTela.text = mediaPontuacao.ToString("F1");
        numeroQuestoes.text = "VOCÊ CONSEGUIU " + pontuacao1 + " PONTOS DE " + questoes*4;

        if(mediaPontuacao >= 0)
            vetorEstrelas[0].sprite = spriteEstrelaPreenchida;

        if(mediaPontuacao >= 6)
            vetorEstrelas[2].sprite = spriteEstrelaPreenchida;

        if(mediaPontuacao == 10)
            vetorEstrelas[1].sprite = spriteEstrelaPreenchida;

    }

    public void voltarMenu(){

        SceneManager.LoadScene("Menu Inicial");

    }

    public void volumeMusica(float value){

        fundoMusical.volume = value;

    }

    public void abrirOpcoes(){

        estadoOpcoes = !estadoOpcoes;

        if (estadoOpcoes){

            botoesQuiz.transform.localScale = Vector3.zero;
            
        }else{

            botoesQuiz.transform.localScale = Vector3.one;
            
        }
        
        painelOpcoes.SetActive(estadoOpcoes);

    }

    public void PlayAudio(){
        if (!dublagem.isPlaying){
            dublagem.Play();
        }
    }

    public void StopAudio(){
        if (dublagem.isPlaying){
            dublagem.Stop();
        }
    }

    public void volumeDublagem(float value){

        dublagem.volume = value;

    }

    void AjustarResolucao(){

        Resolution resolucaoAtual = Screen.currentResolution;
       
    }

}
