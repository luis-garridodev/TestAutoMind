
using System;
using System.Collections.Generic;


namespace cadastroDeUsuarios
{
    public class program
    {
        class Usuario
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public DateTime DataNascimento { get; set; }

            // Alteração: Idade agora é uma propriedade calculada com base na DataNascimento
            public int Idade
            {
                get
                {
                    var hoje = DateTime.Today;
                    var idade = hoje.Year - DataNascimento.Year;
                    if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
                    return idade;
                }
            }
        }

        static void Main(string[] args)
        {
            List<Usuario> usuarios = new List<Usuario>();
            int opcao;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Cadastrar Usuário");
                Console.WriteLine("2. Listar Usuários");
                Console.WriteLine("3. Buscar e exibir um usuário por nome");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Usuario usuario = new Usuario();
                        Console.Write("Nome: ");
                        usuario.Nome = Console.ReadLine();
                        Console.Write("Email: ");
                        usuario.Email = Console.ReadLine();
                        Console.Write("Telefone: ");
                        usuario.Telefone = Console.ReadLine();

                        // Alteração: Solicitar a data de nascimento e calcular a idade
                        Console.Write("Data de Nascimento (dd/MM/yyyy): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
                        {
                            usuario.DataNascimento = dataNascimento;
                            usuarios.Add(usuario);
                        }
                        else
                        {
                            Console.WriteLine("Data de nascimento inválida. Usuário não cadastrado.");
                        }
                        break;

                    case 2:
                        foreach (var u in usuarios)
                        {
                            Console.WriteLine($"Nome: {u.Nome}, Email: {u.Email}, Telefone: {u.Telefone}, Data de Nascimento: {u.DataNascimento.ToShortDateString()}, Idade: {u.Idade}");
                        }
                        break;

                    case 3:
                        Console.Write("\nDigite o nome ou parte do nome do usuário: ");
                        string busca = Console.ReadLine().ToLower();

                        var correspondencias = usuarios.FindAll(u => u.Nome.ToLower().Contains(busca));

                        if (correspondencias.Count == 0)
                        {
                            Console.WriteLine("Nenhum usuário encontrado.");
                        }
                        else if (correspondencias.Count == 1)
                        {
                            var u = correspondencias[0];
                            Console.WriteLine("\n--- Usuário encontrado ---");
                            Console.WriteLine($"Nome : {u.Nome}");
                            Console.WriteLine($"Email: {u.Email}");
                            Console.WriteLine($"Idade: {u.Idade}");
                        }
                        else
                        {
                            Console.WriteLine($"\n{correspondencias.Count} usuários encontrados com esse nome:");
                            for (int i = 0; i < correspondencias.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {correspondencias[i].Nome}");
                            }

                            Console.Write("Escolha o número do usuário para ver os detalhes: ");
                            int indice = int.Parse(Console.ReadLine()) - 1;

                            if (indice >= 0 && indice < correspondencias.Count)
                            {
                                var u = correspondencias[indice];
                                Console.WriteLine("\n--- Usuário selecionado ---");
                                Console.WriteLine($"Nome : {u.Nome}");
                                Console.WriteLine($"Email: {u.Email}");
                                Console.WriteLine($"Idade: {u.Idade}");
                            }
                            else
                            {
                                Console.WriteLine("Índice inválido.");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 4);
        }
    }
    
        
    }

