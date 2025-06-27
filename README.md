
# 🏥 Projeto Clinica.Medica

Bem-vindo ao repositório do **Clinica.Medica**, um sistema web desenvolvido com **ASP.NET Core** seguindo os princípios da **Clean Architecture**. Esta aplicação foi projetada para gerenciar de forma eficiente os atendimentos em uma clínica médica, desde o cadastro de pacientes até o controle de triagens e fila de atendimento.

---

## 📌 Funcionalidades Principais

- ✅ Cadastro de pacientes (nome, telefone, sexo, data de nascimento, e-mail)
- ✅ Geração de número sequencial de atendimento
- ✅ Registro de triagem com sintomas, pressão arterial, peso, altura e especialidade
- ✅ Fila de atendimento com chamada por ordem de chegada e finalização
- ✅ Interface Web (Razor) para interação com usuários
- ✅ API REST para integração e automação
- ✅ Scripts SQL para criação e carga inicial do banco

---

## 🧱 Arquitetura Utilizada

O projeto adota a **Clean Architecture**, garantindo uma estrutura escalável e separação de responsabilidades:

```
Clinica.Medica
│
├── Domain          → Entidades e regras de negócio
├── Application     → Serviços (casos de uso) e DTOs
├── Infrastructure  → Persistência (EF Core, Repositórios)
├── WebUI           → Frontend com Razor Pages
└── API             → Controllers REST (ponto de entrada HTTP)
```

---

## ⚙️ Requisitos

- .NET 8 SDK
- SQL Server LocalDB ou outro SQL Server disponível
- Visual Studio 2022 ou superior (com suporte a ASP.NET e EF Core)

---

## 🚀 Como rodar o projeto localmente

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/Clinica.Medica.git
cd Clinica.Medica
```

### 2. Abra a solução no Visual Studio

Abra o arquivo `Clinica.Medica.sln`.

### 3. Configure a connection string

No `appsettings.json` do projeto `API` e `WebUI`, ajuste a string de conexão com o seu banco SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ClinicaDb;Trusted_Connection=True;"
}
```

### 4. Execute as Migrations (caso use Code First)

No Package Manager Console:

```bash
Update-Database
```

Ou, se preferir, use os scripts SQL prontos em `/Scripts`.

### 5. Rode o projeto

Selecione o projeto `WebUI` como startup e pressione `F5`.

---

## 🧠 Diagramas do Projeto

- ✅ Diagrama UML de Classes
- ✅ Diagrama de Fluxo de Dados (DFD)
- ✅ Diagrama Entidade-Relacionamento (ER)

Esses diagramas estão disponíveis no PDF da documentação e ajudam a entender a estrutura e o fluxo do sistema.

---

## 💽 Scripts SQL

Os scripts de criação (`DDL`) e carga inicial (`DML`) estão prontos para uso e se encontram na pasta `Scripts/`.

Exemplo:

```sql
INSERT INTO Especialidades (Nome)
VALUES ('Cardiologia'), ('Ortopedia'), ('Pediatria');
```

---

Feito com ❤️ e C# para facilitar o atendimento clínico.
