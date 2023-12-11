using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Proyecto_E3_WindowsForms_Csharp
{
    public partial class MainForm : Form
    {

        private LinkedList<int> linkedList;
        private Stack<int> stack;
        private Queue<int> queue;
        private TreeNode rootNode;
        private Graph graph;

        public MainForm()
        {
            InitializeComponent();
            InitializeDataStructures();
        }

        private void InitializeDataStructures()
        {
            // Lista Enlazada
            linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            // Pila
            stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Cola
            queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // Árbol Binario
            rootNode = new TreeNode(1);
            rootNode.Left = new TreeNode(2);
            rootNode.Right = new TreeNode(3);

            // Grafo No Dirigido
            graph = new Graph();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
        }


        private void DisplayData()
        {
            // Mostrar en la interfaz gráfica
            linkedListLabel.Text = "Linked List: " + string.Join(" -> ", linkedList);
            stackLabel.Text = "Stack: " + string.Join(" -> ", stack);
            queueLabel.Text = "Queue: " + string.Join(" -> ", queue);

            // Árbol Binario (Inorder Traversal)
            treeLabel.Text = "Binary Tree (Inorder Traversal): ";
            InorderTraversal(rootNode);

            // Grafo No Dirigido
            graphLabel.Text = "Graph Representation:\n" + graph.GetGraphString();
        }


        private void InorderTraversal(TreeNode node)
        {
            if (node != null)
            {
                InorderTraversal(node.Left);
                treeLabel.Text += $"{node.Value} ";
                InorderTraversal(node.Right);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        public class TreeNode
        {
            public int Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int value)
            {
                Value = value;
            }
        }

        public class Graph
        {
            private Dictionary<int, List<int>> adjacencyList;

            public Graph()
            {
                adjacencyList = new Dictionary<int, List<int>>();
            }

            public void AddVertex(int vertex)
            {
                adjacencyList[vertex] = new List<int>();
            }

            public void AddEdge(int source, int destination)
            {
                adjacencyList[source].Add(destination);
                adjacencyList[destination].Add(source);
            }

            public string GetGraphString()
            {
                string result = "";
                foreach (var vertex in adjacencyList.Keys)
                {
                    result += $"{vertex}: ";
                    result += string.Join(" ", adjacencyList[vertex]);
                    result += "\n";
                }
                return result;
            }
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            DisplayData();
        }
    }

}

