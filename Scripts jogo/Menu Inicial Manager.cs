using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInicialManager : MonoBehaviour{

    private bool estadoMusica = true;
    private bool estadoOpcoes = false;
    private bool estadoCredito = false;
    private bool estadoSobre = false;

    [SerializeField] private GameObject botoesMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelSobre;
    [SerializeField] private GameObject painelCredito;
    [SerializeField] private AudioSource fundoMusical;
    [SerializeField] private Sprite spriteSomLigado;
    [SerializeField] private Sprite spriteSomDesligado;
    [SerializeField] private Image spriteBotaoMute;

    public void jogar(){

        SceneManager.LoadScene("Video1");

    }

    public void abrirOpcoes(){

        estadoOpcoes = !estadoOpcoes;

        if (estadoOpcoes){
            
            botoesMenuInicial.transform.localScale = Vector3.zero;
            
        }else{
            
            botoesMenuInicial.transform.localScale = Vector3.one;
            
        }
        
        painelOpcoes.SetActive(estadoOpcoes);

    }

    public void abrirSobre(){

        estadoSobre = !estadoSobre;

        painelSobre.SetActive(estadoSobre);

    }

    public void abrirCredito(){

        estadoCredito = !estadoCredito;
        
        painelCredito.SetActive(estadoCredito);

    }

    public void volumeMusica(float value){

        fundoMusical.volume = value;

    }

    public void muteMusica(){

        estadoMusica = !estadoMusica;
        fundoMusical.enabled = estadoMusica;
        spriteBotaoMute.sprite = estadoMusica ? spriteSomLigado : spriteSomDesligado;

    }

    public void sair(){

        Application.Quit();

    }

    void AjustarResolucao(){

        Resolution resolucaoAtual = Screen.currentResolution;
       
    }

}
