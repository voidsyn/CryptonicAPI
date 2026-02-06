# CryptonicAPI

Detta är ett webbaserat API byggt i **.NET 10** som översätter text till och från **Rövarspråket**. Projektet är upplagt för att demonstrera ett modernt arbetssätt med automatiserad testning och moln-publicering (CI/CD).

## Testa API:et Live

API:et körs live på AWS Elastic Beanstalk. Du kan testa det direkt i webbläsaren.

**AWS-Sidan:** http://cryptonicapi-env.eba-ejc3swes.eu-north-1.elasticbeanstalk.com/

---

## Så använder du API:et

Det finns två funktioner (endpoints) du kan använda.

### 1. Kryptera text
Gör om vanlig text till Rövarspråket.

* **Adress:** `/Encryption`
* **Parameter:** `text`

**Exempel:**
Lägg till detta i slutet på din länk i webbläsaren:
`/Encryption?text=Hej`

**Svar:**
```json
{
  "original": "Hej",
  "encrypted": "Hohejoj",
  "type": "Rövarspråket"
}
```

2. Avkryptera text
Översätter Rövarspråket tillbaka till vanlig text.

* **Adress:** /Encryption/decrypt
* **Parameter:** text

Exempel: /Encryption/decrypt?text=Hohejoj

**Svar:**
```json
{
  "original": "Hohejoj",
  "encrypted": "Hej",
  "type": "Rövarspråket"
}
```
---
# Kör programmet lokalt

1. Hämta koden: https://github.com/voidsyn/CryptonicAPI.git

2. Gå in i mappen: cd CryptonicAPI
3. Starta programmet: dotnet run --project CryptonicAPI
4. Testa: Öppna din webbläsare och gå till: http://localhost:5000/Encryption?text=Test
---
