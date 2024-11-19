# AgendaConsultorio

Sistema de agendamento para um consultório médico, desenvolvido em C#. Este projeto permite o gerenciamento de pacientes e consultas, oferecendo funcionalidades para cadastro de pacientes, criação de agendamentos e um menu de navegação interativo.

## Funcionalidades

- **Cadastro de Pacientes**: Permite adicionar, editar e excluir dados de pacientes, incluindo CPF e nome.
- **Agendamento de Consultas**: Facilita a criação, visualização e cancelamento de agendamentos para pacientes.
- **Menus Interativos**: Interface de linha de comando com menus para navegação e escolha de operações.

## Estrutura do Projeto

O projeto está dividido nas seguintes classes principais:

- **Program.cs**: Ponto de entrada do programa, responsável por iniciar o sistema e carregar o menu principal.
- **MenuPrincipal.cs**: Interface inicial do sistema, oferecendo opções como cadastro de pacientes e agendamento de consultas.
- **ControleConsultorio.cs**: Classe principal de controle que lida com as operações de negócio do sistema, como a gestão de pacientes e agendamentos.
- **Paciente.cs**: Modelo de dados para representar pacientes, com atributos como CPF e nome.
- **Agendamento.cs**: Modelo para representar agendamentos, incluindo data, horário e associação com um paciente.
- **MenuCadastroPaciente.cs**: Menu específico para a manipulação de dados de pacientes.
- **MenuAgenda.cs**: Menu responsável pela interface de agendamento de consultas.
- **ValidacaoDados.cs**: Classe utilitária para validação de dados, como CPF e datas.

## Como Executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.

### Executando o Projeto

1. Clone o repositório:
  ```bash
  git clone https://github.com/theghhz/residencia-em-software/tree/main/Consultorio
  ```

2. Navegue até o diretório do projeto:
  ```bash  
  cd AgendaConsultorio
  ```
   
3. Compile e execute o projeto:
  ```bash
  dotnet run
  ```

### Uso
1. Após iniciar o programa, você verá o menu principal.
2. Escolha entre as opções para cadastrar pacientes, criar ou visualizar agendamentos, ou sair do sistema.
3. Siga as instruções de cada menu para realizar as operações desejadas.
