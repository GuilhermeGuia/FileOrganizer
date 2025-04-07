# 🗂️ File Organizer

## 💡 Sobre o Projeto

O **File Organizer** é uma aplicação desenvolvida em **C#** com o objetivo de automatizar a **organização de arquivos em diretórios**, categorizando-os com base em sua **extensão** e **data de criação**. 

A ideia surgiu da necessidade comum de manter pastas mais organizadas sem precisar mover tudo manualmente. Com esse script, arquivos são automaticamente distribuídos em pastas como **Imagens**, **Documentos**, **Planilhas**, entre outras, agrupados ainda por **mês e ano de criação**.

---

## 🛠️ Tecnologias e práticas

- ✔️ Desenvolvido em **.NET / C#**
- ✔️ Leitura e manipulação de **arquivos e diretórios**
- ✔️ Leitura de **arquivo de configuração JSON**
- ✔️ Tratamento de exceções (sem permissão, nome duplicado, etc.)
- ✔️ **Log simples** gravado em arquivo e no Console para acompanhar ações (movimentações) e erros.
- ✔️ Estrutura pensada para seguir princípios de **boas práticas**, como:
  - Separação de responsabilidades
  - Modularização do código
  - Organização em camadas/pastas
  - Uso de métodos descritivos e coesos

  

---

## ⚙️ Como usar o script

### 1. Clone o repositório

```bash
git clone https://github.com/GuilhermeGuia/FileOrganizer.git
cd file-organizer
```
### 2. Configure os diretórios no config.json

Localize o arquivo Config/config.json e defina os caminhos:
```javascript
{
  "SourceDirectory": "C:\\Caminho\\Para\\Origem",
  "DestinationDirectory": "C:\\Caminho\\Para\\Destino",
  "FileExtensions": {
    "Imagens": [".jpeg", ".png", ".gif", ".jpg"],
    "Planilhas": [".xlsx", ".xls", ".csv"],
    "Documentos": [".doc", ".docx", ".pdf", ".txt"]
  }
}
```

### 3. Execute o projeto

```bash
dotnet build
dotnet run
```

### 4. 📁 Estrutura básica das pastas de saída
```bash
Destino/
├── Imagens/
│   └── 2024-3/
│       └── imagem.jpg
├── Documentos/
│   └── 2025-1/
│       └── arquivo.pdf
├── Desconhecidos/
│   └── 2025-4/
│       └── outro.arq
```
### 💭 Considerações finais
Esse projeto foi uma oportunidade de praticar:
  - Manipulação de arquivos e diretórios em C#
  - Organização de código limpo
  - Pensar em modularização e responsabilidade única
  - Aprender com erros e exceções comuns do sistema de arquivos
