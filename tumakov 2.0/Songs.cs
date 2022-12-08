using System;
using System.Collections.Generic;
using System.Text;

namespace tumakov_2._0
{
    class Songs
    {
        public string name;
        public string author;
        public Songs prev;

        public void SetName(string name, string author)
        {
            this.name = name;
            this.author = author;
            prev = null;

        }

        public static void GetPrev(string song, List<Songs> list)
        {
            foreach (Songs a in list)
            {
                if (a.name.Equals(song))
                {
                    int i = list.IndexOf(a);
                    if(i != 0)
                    {
                        Songs prev = list[i - 1];
                        a.prev = prev;
                    }
                    else
                    {
                        a.prev = null;
                    }
                    
                    
                }
            }
        }

        static public void PrintList(List<Songs> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Songs song = list[i];
                Songs.GetPrev(song.name,list);
                if(song.prev != null)
                {
                    Console.WriteLine("Name: " + song.name + " Author: " + song.author + " Previous song: " + song.prev.name);
                }
                else
                {
                    Console.WriteLine("Name: " + song.name + " Author: " + song.author);
                }
                
                continue;
            }
        }


    }

}
