using System;
using System.Text.Json;

public class CovidConfig
{
	public string satuan_suhu { get; set; }
	public int batas_hari_demam { get; set; }
	public string pesan_ditolak { get; set; }
	public string pesan_diterima { get; set; }

	public CovidConfig() { }

	public CovidConfig(string satuan_suhu,int batas_hari_demam,string pesan_ditolak,string pesan_diterima)
	{
		this.satuan_suhu = satuan_suhu;
		this.batas_hari_demam = batas_hari_demam;
		this.pesan_ditolak = pesan_ditolak;
		this.pesan_diterima = pesan_diterima;

	}

	public void UbahSatuan()
	{
		if (satuan_suhu == "celcius")
		{
			satuan_suhu = "fahrenheit";
		} 
		else 
		{
			satuan_suhu = "celcius";
		}
	}
}

class UIConfig
{
    public CovidConfig covidConfig;
	public const string fileLocation = "D:\\TELKOM\\SEMESTER 4\\KONSTRUKSI PERANGKAT LUNAK\\tpmodul8_1302213043\\tpmodul8_1302213043\\tpmodul8_1302213043\\";
	public const string filePath = fileLocation + "covid_config.json";

	public UIConfig()
	{
		try
		{
			ReadConfigFile();
		}
		catch (Exception)
		{
			setDefault();
			writeNewConfigFile();
		}
	}

	private CovidConfig ReadConfigFile()
	{
		string configJSONData = File.ReadAllText(filePath);
		covidConfig = JsonSerializer.Deserialize<CovidConfig>(configJSONData);
		return covidConfig;
	}

	private void setDefault()
	{
		
		string pesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
		string pesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

		covidConfig = new CovidConfig("celcius", 14, pesanDitolak, pesanDiterima);
	}

	private void writeNewConfigFile()
	{
		JsonSerializerOptions options = new JsonSerializerOptions()
		{
			WriteIndented = true
		};

		string jsonString = JsonSerializer.Serialize(covidConfig, options);
		File.WriteAllText(filePath, jsonString);
	}
}


