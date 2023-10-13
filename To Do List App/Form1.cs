using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List_App
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable todoList = new DataTable(); // Cria uma tabela para armazenar os itens da lista de tarefas.
        bool isEditing = false; // Uma flag para controlar se o usuário está editando um item existente.

        private void Form1_Load(object sender, EventArgs e)
        {
            todoList.Columns.Add("Title"); // Adiciona uma coluna chamada "Title" à tabela.
            todoList.Columns.Add("Description"); // Adiciona uma coluna chamada "Description" à tabela.

            toDoListView.DataSource = todoList; // Associa a tabela a um controle DataGridView chamado toDoListView.
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            // Limpa os campos de entrada de título e descrição.
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;

            // Preenche os campos de título e descrição com os valores do item selecionado na lista de tarefas.
            titleTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descriptionTextBox.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Remove o item selecionado na lista de tarefas.
                todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                // Se estiver em modo de edição, atualiza o item selecionado com os valores dos campos de título e descrição.
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descriptionTextBox.Text;

            }
            else
            {
                // Caso contrário, adiciona um novo item à lista de tarefas com os valores dos campos de título e descrição.
                todoList.Rows.Add(titleTextBox.Text, descriptionTextBox.Text);
            }

            // Limpa os campos de entrada de título e descrição e redefine a flag de edição.
            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            isEditing = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
