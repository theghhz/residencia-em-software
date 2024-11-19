using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
public class Conversor{
    private static readonly string apiKEY = "4da1e63725f915e703c9d816";
    public string Base_code { get; set; }
    public string Target_code { get; set; }
    public decimal Amount { get; set; }
    public decimal TaxaConversao { get; private set; }

    public Conversor(string base_code, string target_code, decimal amount)
    {
        this.Base_code = base_code;
        this.Target_code = target_code;
        this.Amount = amount;
    }

    private string GetUrl()
    {
        return $"https://v6.exchangerate-api.com/v6/{apiKEY}/pair/{Base_code}/{Target_code}/{Amount}";
    }

    public async Task<(bool, object)> ConverterMoeda(){

        using HttpClient client = new HttpClient();
        string url = GetUrl();

        HttpResponseMessage response = await client.GetAsync(url);

        string data = await response.Content.ReadAsStringAsync();

        try{
            dynamic? json = JsonConvert.DeserializeObject(data);

            if (json == null){
                return (false, "Falha na leitura do JSON.");
            }

            if (response.IsSuccessStatusCode){

                TaxaConversao = json.conversion_rate;

                return (true, Amount * TaxaConversao);
            }else{
                return (false, json["error-type"].ToString());
            }
        }catch(Exception e){
            return (false, e.Message);
        }
    }

}