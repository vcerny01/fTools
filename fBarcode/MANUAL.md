# Manuál
## Konfigurace
### První spuštění
- Při prvním spuštěním programu budete vyzvání nastavit lokaci SQL databáze a heslo k ní.
	- **Lze heslo změnit po nastavení?**
		- Ne. Heslo je unikátní a je jim zakódovaná celá databáze. Pokud ho zapomenete, budete muset vytvořit novou databázi.
	- **Lze změnit lokaci databáze?**
		- Ano, ale kontaktujte při tomto kroku technickou podporu.
	- **Jak vymazat starou databázi a vytvořit novou?**
		- Toto by nemělo být v žádném případě třeba, ale je to možné, kontaktujte technickou podporu pro více informací.
- Dále budete vyzváni k importu seznamu zaměstnanců a typů činností, o tom více v následující sekci

### Konfigurace databáze
- Databázi lze začít konfigurovat otevřením oken pro Import nebo Export stisknutím stejnomenných tlačítek ve Správě mzdy

#### Objekty databáze
- Zaměstnance
- Typy činností (práce)
- Vykonané činnosti zaměstnanců (aktivita)
- Vytvořené zásilky
- Konfigurace programu

#### Export
- Všechny z výše zmíněných objektů databáze krom konfigurace programu lze hromadně exportovat do CSV

#### Import
- Všechny z výše zmíněných objektů lze importovat skrze CSV
	- Stejně jako v exportu, jeden řádek CSV zastupuje jeden objekt, jednotlivé hodnoty jsou oddělovány čárkou
	- **Import zaměstnanců**
		- Při importu zaměstnanců se vymažou stávající objekty, doporučuje se export stávajícíh objektů před importem
		- V importu jsou možné dva typy řádků pro import
			- Řádek z exportu
				- Díky unikátnímu ID se obnoví všechny relace v databázi s tímto objektem spojené
				- Př.: `Jan Novák,ea2ef078-e8b2-46f3-858e-3ed42f9ee5c5,1698671655`
			- Řádek pro tvorbu nového objektu
				- Vyžaduje následující položku: *jméno* (`string`, jméno zaměstnance)
				- Př: `Jan Novák`
	- **Import typů činností**
		- Při importů typů činností se vymažou stávající objekty, doporučujeme se export stávjících objektů před importem
		- V importu jsou možné dva typy řádků pro import
			- Řádek z exportu
				- Díky unikátnímu ID se obnoví všechny relace v databázi s tímto objektem spojené
				- Př. `Úklid pod stolem a okolí,94805ec0-1178-4862-aaac-0c77749c5623,900,1699084504`
			- Řádek pro tvorbu nového objektu
				- Vyžaduje následující položky: *jméno* (`string`, název typu činností), *doba trvání* (`int`, doba trvání práce v sekundách)
				- Př. `Úklid pod stolem a okolí,900`
		- ! V importu musí být zmíněny typy činností pro vytvoření balíků (\_CzechPost, \_Dpd, \_Gls, \_Zasilkovna)
	- **Import proběhlých činností**
		- Proběhlé činnosti lze generovat pouze v programu
		- V importu je možný jeden typ řádku pro import => řádek z exportu
			- Př. `be0643d1-12af-418c-9223-2e19d08cde2f,620531b3-01da-4416-9226-8a983dbf346b,ea2ef078-e8b2-46f3-858e-3ed42f9ee5c5,1,1200,83,1699093150`
	- **Import vytvořených zásilek**
		- Vytvořené zásilky lze generovat pouze v programu
		- V importu je možný jeden typ řádku pro import => řádek z exportu
			- Př. `184c4051-c937-4673-9291-2c80c3cf287a,ea2ef078-e8b2-46f3-858e-3ed42f9ee5c5,231613395,302334162,1699091646`
	- **Import konfigurace programu**
		- Import konfigurace je v CSV, každý řádek obsahuje klíč a hodnotu nastavení oddělené čárkou
			- Př.`Misc.PenaliyationPasswordHash,9214532619c021f511e545812a7bb73908d6e43a75eda839a413f52a71f0d91c`
		- Aby byla konfigurace programem přijata, musí obsahovat VŠECHNY z následujícíh klíčů, nastavení mimo třídu Misc nechte nastavit technickou podporou
			- Pohoda.ConnectionString
			- Pohoda.DatabaseName
			- Pohoda.TableName
			- CzechPost.ApiToken
			- CzechPost.ApiKey
			- CzechPost.PodaciPostaPSC
			- CzechPost.IdLocation
			- CzechPost.ServicePrimary
			- CzechPost.ServiceDobirka
			- CzechPost.ServiceRr
			- CzechPost.ServiceVk
			- CzechPost.IdCustomer
			- CzechPost.IdContract
			- CzechPost.IdForm
			- CzechPost.IdFormRr
			- Dpd.ApiUrl
			- Dpd.Username
			- Dpd.Password
			- Dpd.PayerId
			- Dpd.SenderAddressId
			- Dpd.ServiceMain
			- Dpd.ApplicationType
			- Zasilkovna.Eshop
			- Zasilkovna.ApiUrl
			- Zasilkovna.ApiPassword
			- Gls.ClientNumber
			- Gls.ApiUrl
			- Gls.Username
			- Gls.Password
			- Misc.PrinterName
				- `string`, název tiskárny
			- Misc.SumatraPath
				- `string`, absolutní cesta k programu SumatraPDF
			- Misc.HourlySalary
				- `int`, mzda (v Kč) za hodinu práce
			- Misc.PenalizationRateInSeconds
				- `int`, základní sazba penalizace v sekundách
			- Misc.PenalizationPasswordHash
				- `string`, SHA256 hash hesla pro administraci penalizací (pro jeho tvorbu kontaktujte technickou podporu)

## Tisk štítků
- Před tiskem se ujistěte, že máte zvolený svůj profil, aby se vytvořené zásilky přidávaly k vašemu profilu
- Uživatelské možnosti pro tisk
	- (Možnosti napravo zůstanou aktivovány pouze pro tisk každého štítku)
	- **PDF**
		- Místo poslání štítku na tiskárnu, bude štítek uložen na vámi zvolené místo v počítači
	- **Zkontrolovat!**
		- Po načtení údajů o zásilce budete mít možnost údaje zkontrolovat a na základě toho se rozhodnout, jestli chcete v tisku pokračovat
	- **VK!**
		- Jako vícekusé zásilky jsou automaticky brány všechny s váhou nad 24 kg, nicméně vícekus lze vynutit i u zásilek s nižší hmotností aktivací této možnosti
	- **Doposílka!**
		- Zásilka je označena jako doposílka (relevantní pouze pro zásilky české pošty)
- Pro vytvoření nové zásilky stačí do textového pole vložit číslo faktury a v případě, že není automaticky rozpoznáno, stisknout tlačítko 'Vytvořit zásilku'

## Správa mzdy
### Pro zaměstnance
- Ve Správě mzdy existují vidíte v poli Přehled přehled co se týče mzdy aktuálně zvoleného zaměstnance a v poli Záznam činností záznam činností všech zaměstnanců za dnešní den
- Zaměstnanec poté co se ujistí, že má zvolený svůj profil, může přidat jím vykonanou činnost do databáze tak, že jí zvolí z nabídky, vloží počet její kvantity a nakonec jí přidá tlačítkem ENTER

### Pro nadřízeného
- Nadřízený, pokud zná heslo pro administraci penalizací, může zvolenému zaměstnanci udělit penalizaci jako libovolný násobek základní penalizační časové sazby
- Dále může pomocí funkce Vyhledávání dohledat informace o vytvořené zásilce pomocí variabilního symbolu dané zásilky

### Další možnosti pro práci s databází
#### Generování výkazů
- V okně Exportu, lze generovat i výkazy za libovolný časový interval z nabídky
	- Výkaz obsahuje:
		- Přehled všech vytvořených zásilek (číslo faktury, variabilní symbol)
		- Přehled aktivity na typech činností (název typu činnosti, vykonaná kvantita všemi zaměstnanci)
		- Přehled produktivity zaměstnanců (jméno zaměstnanc, odpracovaný čas v minutách)
- Dále lze v okně exportu taky mazat libovolné záznamy z databáze
	- Záznamy se mažou příkazem do textového pole dole v okně pro Export a stiskem tlačítka Vymazat záznam se spustí
	- Syntax pro příkaz začíná velkým písmenem specifiukující typ objektu (W pro zaměstnance, J pro typy činností, A pro vykonané činnosti, P pro vytvořené zásilky), pak přichází oddělující čárka a po ní libovolný počet GUIDs (druhá položka v řádku exportu zaměstnanců a typů činností a první položka v řádku exportu vykonaných činností a vytvořených zásilek) objektů daného typu oddělených čárkou
		- Mazání objektů z databáze by mělo být třeba pouze v případě závažné chyby a doporučuje se export před jejím provedením