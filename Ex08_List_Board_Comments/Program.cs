using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08_List_Board_Comments
{
    /*
        APP ----- DataBase 
            (CRUD)
         
        1. select 
        2. insert
        3. update 
        4. delete
        
        create table Board(boardid int .....);
        create table comments(commentid int....);
        
        APP : select boardid, title, content from board;
        객체지향언어
        객체 매핑
        
        class Board{
         private int boardid;
        }
        class Comments{
         private int commentid;
        }
        
        1. Case_1 1건의 데이터 넣기
        -> select boardid, title from board where boardid = 2;
           Board board = new Board();
           board.boardid = 위에 select해서 DB에서 갖고 온 데이터
        
        2. Case_2 여러건의 데이터는 어떻게?
        -> select boardid, title from board --> 예를들어 데이터가 150건이면?
            List<Board> boardlist = new ......
            boardlist.add(new board());
            ...
            ....
            boardlist 안에 Board 객체 150개가 생성됨 !
     */

    class Board
    {
        // title, contents, ... 일단 얘내들 생략하고
        private List<Comments> comments;    // List가 이런 식으로 활용되기때문에 꼭 알아야된다.(전자제품 예제 등 List 예제 많이봐두자)
        
        public void addComment(Comments comment)
        {
            comments.Add(comment);      //댓글 write
        }
    }
    class Comments
    {
        private Board board;

        public void setBoard(Board board)
        {
            this.board = board;
            board.addComment(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.addComment(new Comments());
            board.addComment(new Comments());
            board.addComment(new Comments());
        }
    }
}
