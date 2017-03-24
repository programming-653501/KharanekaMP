using System;

namespace lab5._2._30
{
    class Tree
    {
        private string value;
        private Tree left;
        private Tree right;

        // вставка
        public void Insert(string value)
        {
            if (this.value == null)
                this.value = value;
            else
            {
                if (this.value.CompareTo(value) == 1)
                {
                    if (left == null)
                        this.left = new Tree();
                    left.Insert(value);
                }
                else if (this.value.CompareTo(value) == -1)
                {
                    if (right == null)
                        this.right = new Tree();
                    right.Insert(value);
                }
                else
                    throw new Exception("Узел уже существует");
            }

        }
        
        public string Display(Side s)
        {
            return Display(this, s);
        }

        private string Display(Tree t, Side s)
        {
            string result = "";

            if ((s == Side.left ? t.left : t.right) != null)
                result += Display(s == Side.left ? t.left : t.right, s);

            result += t.value + " ";

            if ((s == Side.left ? t.right : t.left) != null)
                result += Display(s == Side.left ? t.right : t.left, s);

            return result;
        }
    }

    public enum Side
    {
        left,
        right
    }
}
