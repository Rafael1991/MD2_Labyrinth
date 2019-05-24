
using UnityEngine;

public class Board : MonoBehaviour {

    public const int BoardSize = 12;
    public Tile[,] tiles;
    
    public Board() { // This constructor initializes the board.
        tiles = new Tile[BoardSize, BoardSize];
        for (int x = 0; x < BoardSize; x++) {
            for (int y = 0; y < BoardSize; y++) {
                tiles[x,y] = new Tile();
            }
        }
    }
}
