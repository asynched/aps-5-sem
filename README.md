# APS 5° semestre

Atividades práticas supervisionadas desenvolvidas para o 5° semestre de Ciência da Computação.

## Sobre o projeto

O projeto é um chat em tempo real desenvolvido utilizando C# e React. A ideia é que o usuário possa conversar com outros usuários, enviar mensagens, e que o chat seja real-time.

## Como instalar?

### Requisitos
- Git
- Git Bash (windows)
- C# - Linguagem utilizada para o servidor;
- NodeJS - Runtime para executar o front-end.

### Clonando o repositório

No terminal, execute:

```sh
$ git clone git@github.com:asynched/aps-5-sem.git
```

### Executando o back-end

Para iniciar o servidor websocket, execute:

```sh
$ cd backend # Entrar na pasta do servidor
$ dotnet run # Executar o servidor
```

### Executando o front-end

Para executar o front-end será necessário criar um arquivo de configuração no diretório do projeto.

```sh
VITE_APP_WEBSOCKET_URL=ws://localhost:8080/ # Exemplo, por padrão a porta do servidor websocket é a 8080.
```

```sh
$ cd frontend # Entrar na pasta do front-end
$ npm run dev # Executar o servidor
```
