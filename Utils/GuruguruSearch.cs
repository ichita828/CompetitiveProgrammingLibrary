Guruguru()
{
  for (int i = 0; i < Min(H, W); ++i)
  {
    for (int j = 0; j < W - i; ++j)//1->2
    {
      Write(i, j);
    }
    for (int j = i; j < H - i; ++j)//2->3
    {
      Write(j, W - 1 - i);
    }
    for (int j = W - 1 - i; j >= i; --j)//3->4
    {
      Write(H - 1 - i, j);
    }
    for (int j = W - 1 - i; j >= i; --j)//4->5
    {
      Write(j, i);
    }
  }
}