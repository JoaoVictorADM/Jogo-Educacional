using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManagerScript : MonoBehaviour{

    private bool estadoOpcoes = false;
    [SerializeField] private AudioSource somVideo;
    [SerializeField] public VideoPlayer videoPlayer; 
    [SerializeField] public string cenaAposVideo; 
    [SerializeField] private GameObject BotoesOpMenuPular;
    [SerializeField] private GameObject painelPularVideo;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] public string cenaMenu; 


    private void Start(){

        AjustarResolucao();

        // Inscreva-se no evento loopPointReached do VideoPlayer
        videoPlayer.loopPointReached += OnVideoFinished;

        // Certifique-se de que o vídeo não esteja configurado para fazer loop (Loop deve estar desativado no VideoPlayer)
        videoPlayer.isLooping = false;
    }

    private void OnVideoFinished(VideoPlayer vp){

        // Carregue a cena especificada após o vídeo
        SceneManager.LoadScene(cenaAposVideo);
    }

    public void AbrirOpcoes(){

        estadoOpcoes = !estadoOpcoes;

        if(estadoOpcoes){
            videoPlayer.Pause();
        } else{
            videoPlayer.Play();
        }

        BotoesOpMenuPular.SetActive(!estadoOpcoes);

        painelOpcoes.SetActive(estadoOpcoes);

    }

    public void AbrirPopUpPularVideo(){

        painelPularVideo.SetActive(true);
        BotoesOpMenuPular.SetActive(false);

    }

    public void PularVideo(int pulaVideo){

        if(pulaVideo == 1){

            SceneManager.LoadScene(cenaAposVideo);

        } else{

            painelPularVideo.SetActive(false);
            BotoesOpMenuPular.SetActive(true);

        }

    }

    public void DiminuirVolume(float value){

        somVideo.volume = value;

    }


    public void VoltarMenu(){

        SceneManager.LoadScene(cenaMenu);

    }

    void AjustarResolucao(){

        Resolution resolucaoAtual = Screen.currentResolution;
       
    }
}
