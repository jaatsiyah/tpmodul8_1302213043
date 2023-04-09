class Program
{
    public static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();
        UIConfig uiConfig = new UIConfig();

        
        uiConfig.covidConfig.UbahSatuan();

        Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " +  uiConfig.covidConfig.satuan_suhu);
        double suhu = double.Parse(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam ?");
        int hari = int.Parse(Console.ReadLine());


        if( hari < uiConfig.covidConfig.batas_hari_demam)
        {
            if (uiConfig.covidConfig.satuan_suhu == "celcius" && suhu >= 36.5 && suhu <= 37.5)
            {
                Console.WriteLine(uiConfig.covidConfig.pesan_diterima);

            } 
            else if (uiConfig.covidConfig.satuan_suhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5)
            {
                Console.WriteLine(uiConfig.covidConfig.pesan_diterima);
            }else
            {
                Console.WriteLine(uiConfig.covidConfig.pesan_ditolak);
            }
        }else
        {
            Console.WriteLine(uiConfig.covidConfig.pesan_ditolak);
        }
    }
}
