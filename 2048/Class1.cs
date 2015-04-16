using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2048
{
    [Serializable]
    class Class1
    {
        public int[,] i = new int[6, 6];                //使用6*6数组的原因是可以简化避免监测是否Game Over时的数组索引报错
        public int grade { get; private set; }          //存储当前成绩
        public int bestGrade { get ;set;}               //存储最好成绩    
        private int quantity { get; set; }              //当前有多少个方块不为0
        private Random ra = new Random();
        public bool die = false;                        //是否Game Over
        public bool change = false;                     //按下某个方向键后会记录方块可否移动
        public void Reset()
        {
            for (int x = 0; x <= 5; x++)
                for (int y = 0; y <= 5; y++)
                    i[x, y] = 0;
            quantity = 0;
            die = false;
            if (grade > bestGrade)
                bestGrade = grade;
            grade = 0;
            Add();
            Add();
        }                          //刷新所有方块 重新开始
        public void Add()
        {
            int x = ra.Next(1, 5);
            int y = ra.Next(1, 5);
            if (i[x, y] == 0)
            {
                if (ra.Next(1, 101) >= 90)
                    i[x, y] = 4;
                else i[x, y] = 2;
                quantity++;
                Die();
            }
            else Add();
        }                            //添加一个元素 添加方法很无脑，用了递归的方法：随机选出一个元素，如果这个元素不为0，那就继续随机加一个，知道成功
        #region 上下左右——非零元素处理  上下左右处理时采用了先处理0元素，再处理非0元素的方法，感觉写的不好，但运行效果还可以
        public void Down()
        {
            change = false;
            down();
            for (int x = 1; x <= 4; x++)
            {
                if (i[x, 4] == i[x, 3] && i[x, 4] + i[x, 3] != 0)
                {
                    if (i[x, 2] == i[x, 1])
                    {
                        i[x, 4] *= 2;
                        i[x, 3] = i[x, 2] * 2;
                        i[x, 2] = 0;
                        i[x, 1] = 0;
                        grade += i[x, 4] + i[x, 3];
                    }
                    else
                    {
                        i[x, 4] *= 2;
                        i[x, 3] = i[x, 2];
                        i[x, 2] = i[x, 1];
                        i[x, 1] = 0;
                        grade += i[x, 4];
                    }
                    change = true;
                }
                else if (i[x, 3] == i[x, 2] && i[x, 3] + i[x, 2] != 0)
                {
                    i[x, 3] *= 2;
                    i[x, 2] = i[x, 1];
                    i[x, 1] = 0;
                    change = true;
                    grade += i[x, 3];
                }
                else if (i[x, 2] == i[x, 1] && i[x, 2] + i[x, 1] != 0)
                {
                    i[x, 2] *= 2;
                    i[x, 1] = 0;
                    change = true;
                    grade += i[x, 2];
                }
            }
            GetQuantity();
        }
        public void Up()
        {
            change = false;
            up();
            for (int x = 1; x <= 4; x++)
            {
                if (i[x, 1] == i[x, 2] && i[x, 1] + i[x, 2] != 0)
                {
                    if (i[x, 3] == i[x, 4])
                    {
                        i[x, 1] *= 2;
                        i[x, 2] = i[x, 3] * 2;
                        i[x, 3] = 0;
                        i[x, 4] = 0;
                        grade += i[x, 1] + i[x, 2];
                    }
                    else
                    {
                        i[x, 1] *= 2;
                        i[x, 2] = i[x, 3];
                        i[x, 3] = i[x, 4];
                        i[x, 4] = 0;
                        grade += i[x, 1];
                    }
                    change = true;
                }
                else if (i[x, 2] == i[x, 3] && i[x, 2] + i[x, 3] != 0)
                {
                    i[x, 2] *= 2;
                    i[x, 3] = i[x, 4];
                    i[x, 4] = 0;
                    change = true;
                    grade += i[x, 2];
                }
                else if (i[x, 3] == i[x, 4] && i[x, 3] + i[x, 4] != 0)
                {
                    i[x, 3] *= 2;
                    i[x, 4] = 0;
                    change = true;
                    grade += i[x, 3];
                }
            }
            GetQuantity();
        }
        public void Left()
        {
            change = false;
            left();
            for (int y = 1; y <= 4; y++)
            {
                if (i[1, y] == i[2, y] && i[1, y] + i[2, y] != 0)
                {
                    if (i[3, y] == i[4, y])
                    {
                        i[1, y] *= 2;
                        i[2, y] = i[3, y];
                        i[3, y] = 0;
                        i[4, y] = 0;
                        grade += i[1, y] + i[2, y];

                    }
                    else
                    {
                        i[1, y] *= 2;
                        i[2, y] = i[3, y];
                        i[3, y] = i[4, y];
                        i[4, y] = 0;
                        grade += i[1, y];
                    }
                    change = true;
                }
                else if (i[2, y] == i[3, y] && i[2, y] + i[3, y] != 0)
                {
                    i[2, y] *= 2;
                    i[3, y] = i[4, y];
                    i[4, y] = 0;
                    change = true;
                    grade += i[2, y];
                }
                else if (i[3, y] == i[4, y] && i[3, y] + i[4, y] != 0)
                {
                    i[3, y] *= 2;
                    i[4, y] = 0;
                    change = true;
                    grade += i[3, y];
                }
            }
            GetQuantity();
        }
        public void Right()
        {
            change = false;
            right();
            for (int y = 1; y <= 4; y++)
            {
                if (i[4, y] == i[3, y] && i[4, y] + i[3, y] != 0)
                {
                    if (i[2, y] == i[1, y])
                    {
                        i[4, y] *= 2;
                        i[3, y] = i[2, y];
                        i[2, y] = 0;
                        i[1, y] = 0;
                        grade += i[4, y] + i[3, y];
                    }
                    else
                    {
                        i[4, y] *= 2;
                        i[3, y] = i[2, y];
                        i[2, y] = i[1, y];
                        i[1, y] = 0;
                        grade += i[4, y];
                    }
                    change = true;
                }
                else if (i[3, y] == i[2, y] && i[3, y] + i[2, y] != 0)
                {
                    i[3, y] *= 2;
                    i[2, y] = i[1, y];
                    i[1, y] = 0;
                    change = true;
                    grade += i[3, y];
                }
                else if (i[2, y] == i[1, y] && i[3, y] + i[1, y] != 0)
                {
                    i[2, y] *= 2;
                    i[1, y] = 0;
                    change = true;
                    grade += i[2, y];
                }
            }
            GetQuantity();
        }
        
        private void down()
        {
            for (int x = 1; x <= 4; x++)
            {
                if (i[x, 4] == 0 && i[x, 1] + i[x, 2] + i[x, 3] != 0)
                {
                    i[x, 4] = i[x, 3];
                    i[x, 3] = i[x, 2];
                    i[x, 2] = i[x, 1];
                    i[x, 1] = 0;
                    change = true;
                    down();
                }
                else if (i[x, 3] == 0 && i[x, 1] + i[x, 2] != 0)
                {
                    i[x, 3] = i[x, 2];
                    i[x, 2] = i[x, 1];
                    i[x, 1] = 0;
                    change = true;
                    down();
                }
                else if (i[x, 2] == 0 && i[x, 1] != 0)
                {
                    i[x, 2] = i[x, 1];
                    i[x, 1] = 0;
                    change = true;
                }
            }
        }
        private void up()
        {
            for (int x = 1; x <= 4; x++)
            {
                if (i[x, 1] == 0 && i[x, 4] + i[x, 3] + i[x, 2] != 0)
                {
                    i[x, 1] = i[x, 2];
                    i[x, 2] = i[x, 3];
                    i[x, 3] = i[x, 4];
                    i[x, 4] = 0;
                    change = true;
                    up();
                }
                else if (i[x, 2] == 0 && i[x, 4] + i[x, 3] != 0)
                {
                    i[x, 2] = i[x, 3];
                    i[x, 3] = i[x, 4];
                    i[x, 4] = 0;
                    change = true;
                    up();
                }
                else if (i[x, 3] == 0 && i[x, 4] != 0)
                {
                    i[x, 3] = i[x, 4];
                    i[x, 4] = 0;
                    change = true;
                }
            }
        }
        private void left()
        {
            for (int y = 1; y <= 4; y++)
            {
                if (i[1, y] == 0 && i[4, y] + i[3, y] + i[2, y] != 0)
                {
                    i[1, y] = i[2, y];
                    i[2, y] = i[3, y];
                    i[3, y] = i[4, y];
                    i[4, y] = 0;
                    change = true;
                    left();
                }
                else if (i[2, y] == 0 && i[4, y] + i[3, y] != 0)
                {
                    i[2, y] = i[3, y];
                    i[3, y] = i[4, y];
                    i[4, y] = 0;
                    change = true;
                    left();
                }
                else if (i[3, y] == 0 && i[4, y] != 0)
                {
                    i[3, y] = i[4, y];
                    i[4, y] = 0;
                    change = true;
                }
            }
        }
        private void right()
        {
            for (int y = 1; y <= 4; y++)
            {
                if (i[4, y] == 0 && i[1, y] + i[2, y] + i[3, y] != 0)
                {
                    i[4, y] = i[3, y];
                    i[3, y] = i[2, y];
                    i[2, y] = i[1, y];
                    i[1, y] = 0;
                    change = true;
                    right();
                }
                else if (i[3, y] == 0 && i[1, y] + i[2, y] != 0)
                {
                    i[3, y] = i[2, y];
                    i[2, y] = i[1, y];
                    i[1, y] = 0;
                    change = true;
                    right();
                }
                else if (i[2, y] == 0 && i[1, y] != 0)
                {
                    i[2, y] = i[1, y];
                    i[1, y] = 0;
                    change = true;
                }
            }
        }
        #endregion 
        private void GetQuantity()
        {
            int count = 0;
            for (int x = 1; x <= 4; x++)
                for (int y = 1; y <= 4; y++)
                {
                    if (i[x, y] != 0)
                        count++;
                }
            quantity = count;
        }                   //获得当前有多少个方块不为0
        private void Die()
        {
            int count = 0;
            if (quantity == 16)
            {
                for (int x = 1; x <= 3; x += 2)
                    for (int y = 1; y <= 3; y += 2)
                        if (!GetEqual(x, y))
                            count++;
                for (int x = 2; x <= 4; x += 2)
                    for (int y = 2; y <= 4; y += 2)
                        if (!GetEqual(x, y))
                            count++;
                if (count == 8)
                    die = true;
            }
        }                           //检测是否Game Over 最后赋值到die。检测方法：获得当前方块数，如果是16，再检测互不相邻的8个方块与自身周围的方块是否相等，如果都不相等，则Game Over
        private bool GetEqual(int x, int y)
        {

            if (i[x, y] == i[x - 1, y])
                return true;
            else if (i[x, y] == i[x + 1, y])
                return true;
            else if (i[x, y] == i[x, y - 1])
                return true;
            else if (i[x, y] == i[x, y + 1])
                return true;
            else return false;

        }          //判断元素与相邻元素是否相等 
    }
}
