using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_092
{
    class Node
    {
        public int nomorBuku, tahunTerbit;
        public string judulBuku, namaPengarang;
        public Node next;
        
    }
    
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void Input()
        {
            int nomorbuku, tahunterbit;
            string judulbuku, namapengarang;

            Console.Write("\nMasukkan Nomor Buku: ");
            nomorbuku = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Judul Buku: ");
            judulbuku = Console.ReadLine();
            Console.Write("\nMasukkan Nama Pengarang: ");
            namapengarang = Console.ReadLine();
            Console.Write("\nMasukkan Tahun Terbit: ");
            tahunterbit = Convert.ToInt32(Console.ReadLine());
            Node nodeBaru = new Node();
            nodeBaru.nomorBuku = nomorbuku;
            nodeBaru.judulBuku = judulbuku;
            nodeBaru.namaPengarang = namapengarang;
            nodeBaru.tahunTerbit = tahunterbit;

            if (START == null || nomorbuku <= START.nomorBuku)
            {
                if ((START != null) && (nomorbuku == START.nomorBuku))
                {
                    Console.WriteLine("\nNomor Buku ini sudah ada\n");
                    return;
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nomorbuku >= current.nomorBuku))
            {
                if (nomorbuku == current.nomorBuku)
                {
                    Console.WriteLine("\nNomor Buku ini sudah ada\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            nodeBaru.next = current;
            previous.next = nodeBaru;
        }
        public bool Delete(int nomorbuku)
        {
            Node previous, current;
            previous = current = null;

            if (Search(nomorbuku, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool Search(int tahunterbit, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (tahunterbit != current.tahunTerbit))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public void Display()
        {
            if (START == null)
            {
                Console.WriteLine("Data Kosong");
                return;
            }
            Node display;
            for (display = START; display != null; display = display.next)
                Console.WriteLine(display.nomorBuku);
        }
        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambah data");
                    Console.WriteLine("2. Menampilkan data");
                    Console.WriteLine("3. Menghapus Data");
                    Console.WriteLine("4. Mencari data");
                    Console.WriteLine("5. Exit");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.Input();
                            }
                            break;
                        case '2':
                            {
                                obj.Display();
                            }
                            break;
                        case '3':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Console.Write("\nMasukkan nomor buku yang akan dihapus: ");
                                int nomorbuku = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.Delete(nomorbuku) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                    Console.WriteLine("Data dengan nomor  " + " dihapus ");
                            }
                            break;
                        case '4':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList Kosong !");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan nomor buku yang akan dicari: ");
                                int tahunterbit = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(tahunterbit, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                {
                                    Console.WriteLine("\nData ketemu");
                                    Console.WriteLine("\nNomor Buku: " + current.nomorBuku);
                                    Console.WriteLine("\nJudul Buku: " + current.judulBuku);
                                    break;
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan tidak valid");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck nilai yang anda masukkan.");
                }
            }
        }
    }
}



//2.) Algoritma Singly Linked List karena tidak ada batasan
//3.) Stack array dan stack linked list
//4.) Pop and Push
//5.) a. b.
