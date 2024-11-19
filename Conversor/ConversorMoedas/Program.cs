using System;
using Newtonsoft.Json;

class Program{

    static void Main(){
        string controlador = "MENU";
        do{
            Menu.Exibir();
            
        }while(controlador == "MENU");
    }

}