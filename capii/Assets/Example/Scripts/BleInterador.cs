using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Android.BLE;
using Android.BLE.Commands;
using UnityEngine.Android;
using UnityEngine.UI;
using System.Text;
using TMPro;
using System;

public class BleInterador : MonoBehaviour
{
    [SerializeField]
    private Button botaoConectar, botaoDesconectar;
    [SerializeField]
    TextMeshProUGUI status;
    [SerializeField]
    string nomeDispositivo;
    [SerializeField]
    private string _servico = "ffe0", _caracteristica = "ffe1";


    //aqui
    [SerializeField]
    private int _scanTime = 10;




    private ConnectToDevice _connectCommand;



    IConexao conexao;

    private void Start()
    {
#if !UNITY_EDITOR
        conexao = new BleInteradorAndroid(status, _scanTime,nomeDispositivo,_servico,_caracteristica,Receber, botaoConectar,botaoDesconectar,null,null);
#endif
#if UNITY_EDITOR
        conexao = new BleInteradorWin(status, _scanTime, nomeDispositivo, _servico, _caracteristica,Receber, botaoConectar, botaoDesconectar, null, null);
#endif
        botaoConectar.interactable = true;
        botaoDesconectar.interactable = false;
    }
#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        BleApi.Quit();
    }
#endif


    public void ScanForDevices()
    {
        conexao.OnScan();
    }

    public void DisconnectDevice()
    {
        conexao.OnDesconectar();//desconecta o device     
    }

    private void Update()
    {
        conexao.Update_Unity();
    }

    private void OnDisconnected(string deviceUuid)
    {
        _connectCommand.End();
    }

    public void EnviarJogoNumeros()
    {
        if (Input.GetButtonDown("1234")) //iniciar jogo
        {
            conexao.Enviar("NUMERO");
        }
    }

    public void EnviarRespostaCerta()
    {
        if (Input.GetButtonDown("3")) //Resposta certa
        {
            conexao.Enviar("C");
        }
    }

    public void EnviarRespostaErrada()
    {
        if (Input.GetButtonDown("1") && Input.GetButtonDown("5")) //Resposta errada
        {
            conexao.Enviar("E");
        }
    }
   
    public void Receber(string dados)
    {
        string receber = Console.ReadLine();
        status.text = dados;

        if (dados == "MUSICA") //Tocar a musica
        {
            conexao.Enviar("JOGOMUSIC1");
        }
        if (dados == "T") //Chamar tela que acertou e envia pro console FIM 
        {

            Debug.Log("FIM");
        }
        if (dados == "F") //Chamar tela que errou e envia pro console FIM 
        {

            Debug.Log("FIM");
        }
        if (receber == "FIM") { //Volta para a tela de atividades
            conexao.Enviar("ACABOU");

        }
    }
}
