namespace TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Add(50);
            binaryTree.Add(25);
            binaryTree.Add(75);
            binaryTree.Add(40);
            binaryTree.Add(38);
            binaryTree.Add(23);
            binaryTree.Add(24);
            binaryTree.Add(10);
            binaryTree.Add(100);
            binaryTree.Add(50);
            binaryTree.Add(25);
            binaryTree.Add(75);
            binaryTree.Add(40);
            binaryTree.Add(38);
            binaryTree.Add(23);
            binaryTree.Add(24);
            binaryTree.Add(10);
            binaryTree.Add(100);

            binaryTree.Delete(50);
           //binaryTree.Delete(50);


            PopulateTreeView(binaryTree);
            treeView1.ExpandAll();

        }

        private void PopulateTreeView(BinaryTree<int> binaryTree)
        {
            if (binaryTree.Root == default) return;
            PopulateTreeView(binaryTree.Root, default);

        }
        private void PopulateTreeView(TreeElement<int> element, TreeNode current)
        {

            TreeNode node = new TreeNode(element.Value.ToString());

            if (current == default) treeView1.Nodes.Add(node);
            else current.Nodes.Add(node);

            if(element.Left != default)
            {
                PopulateTreeView(element.Left, node);
            }
            if(element.Right != default)
            {
                PopulateTreeView(element.Right, node);
            }
        }

    }
}