//"acao" está recebendo uma função não executada, já que está sendo atribuída sem os ()
Action acao = FuncaoSemParametro;
//Neste caso, o atributo está sendo armazenado juntamente com a variável (a execução não recebe parâmetro)
acao = () => FuncaoComParametro("Parametro na definição da variável");
acao();
//Nesse caso, a função está sendo armazenada com o tipo de parâmetro que ela espeara, mas sem o valor (o valor será repassado na execução da "acao1("teste")"
Action<string> acao1 = FuncaoComParametro;
acao1("Parâmetro na execução da Action ou função");

void FuncaoSemParametro() => Console.WriteLine("Função sem parâmetro");
void FuncaoComParametro(string texto) => Console.WriteLine(texto);

//ActionChaining (encadeamento de funções): Fluxo de funções que será armazenada no Action, e a execução deste fluxo de funções será executada com 1 único comando: "handle()". O fluxo será interrompido, caso estoure um Exception (caso seja necessário seguir o fluxo, mesmo com a Exception, fazer um Try Catch na Action)
//É uma boa prática por conta do reuso e facilidade de manutenção: a função "VerificaSeEmailEstaEmUso" (quebrada e independente de outras funções), pode fazer parte de distintos fluxos de funções no projeto
//Exemplo: em um projeto com vários sistemas integrados, é possível criar as funções dentro de suas classes (cada classe em seu departamento: finceiro, folha de pagamento...), e fluxos completos de funções em sequência, que possui seu próprio fluxo e tratamento específico
Action handle = VerificaRequisicao;
handle += VerificaSeEmailEstaEmUso;
handle += GeraOUsuario;
handle += GeraOAluno;
handle += PersisteOsDados;
handle += EnviaCodigoDeAtivacao;
handle += LogaANovaContaCriada;

handle();

void VerificaRequisicao() => Console.WriteLine("1");
void VerificaSeEmailEstaEmUso() => Console.WriteLine("2");
void GeraOUsuario() => Console.WriteLine("3");
void GeraOAluno() => Console.WriteLine("4");
void PersisteOsDados() => Console.WriteLine("5");
void EnviaCodigoDeAtivacao() => Console.WriteLine("6");
void LogaANovaContaCriada() => Console.WriteLine("7");