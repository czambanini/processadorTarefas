namespace ProcessadorTarefas.Entidades
{
    public struct Subtarefa
    {
        public TimeSpan Duracao { get; set; }

        public Subtarefa() {
            Random random = new Random();
            Duracao = TimeSpan.FromSeconds(random.Next(3, 10)); //segundos de duração da subtarefa
        }
    }

}
