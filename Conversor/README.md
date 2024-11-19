# Conversor de Moedas utilizando API

Sistema de conversão de valores de moedas, desenvolvido em C#. Este projeto permite converter valores entre diferentes moedas suportadas pela API, utilizando taxas de câmbio atualizadas.

## Funcionalidades

- **Conversão de valores**: Converte valores entre moedas com as taxas de câmbio atualizadas, adquiridas em tempo real por meio de uma API de câmbio.
- **Menus Interativos**: Interface de linha de comando simples e intuitiva para entrada e escolha das moedas, além da definição do valor a ser convertido.

## Estrutura do Projeto

O projeto está organizado nas seguintes classes principais:

- **Program.cs**: Ponto de entrada do programa, responsável por iniciar o sistema e carregar o menu.
- **Menu.cs**: Interface inicial do sistema, onde o usuário pode escolher as moedas e inserir o valor a ser convertido.
- **ConversorDados.cs**: Classe responsável pela verificação e validação dos dados de entrada, como o formato do valor e a moeda.
- **Conversor.cs**:  Classe principal que faz a requisição à API de câmbio para obter a taxa de conversão e realiza o cálculo do valor convertido.

## Como Executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.

### Executando o Projeto

1. Clone o repositório:
  ```bash
  git clone https://github.com/seuusuario/Conversor.git
  ```

2. Navegue até o diretório do projeto:
  ```bash  
  cd Conversor
  ```
   
3. Compile e execute o projeto:
  ```bash
  dotnet run
  ```

### Uso
1. Após iniciar o programa, você verá o menu principal.
2. Escolha entre as opções para cadastrar pacientes, criar ou visualizar agendamentos, ou sair do sistema.
3. Siga as instruções de cada menu para realizar as operações desejadas.

### ExchangeRate-API

API utilizada: [ExchangeRate-API](https://www.exchangerate-api.com/)

