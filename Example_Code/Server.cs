using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace ChattingServer
{
    class User
    {
        private const int BUFFER_SIZE = 256;

        public Socket client;   // 클라이언트 저장용 소켓
        public byte[] sBuffer = new byte[BUFFER_SIZE];  // 송신 버퍼
        public byte[] rBuffer = new byte[BUFFER_SIZE];  // 수신 버퍼

        public User() { }
        public User(Socket _sock) {
            client = _sock;
        }

        public void CloseUser()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            client = null;
        }

        public void ClearSendBuffer()
        {
            Array.Clear(sBuffer, 0, sBuffer.Length);
        }

        public void ClearReceiveBuffer()
        {
            Array.Clear(rBuffer, 0, rBuffer.Length);
        }

        public void ReceiveCallBack(IAsyncResult ar)
        {
            List<User> _userlist = (List<User>)ar.AsyncState;

            Console.WriteLine("{0}님이 데이터를 보냈습니다. ", client.Handle);

            // 클라이언트가 보낸 메시지를 다른 유저에게 전송해 주어야 한다.
            foreach( User one in _userlist )
            {
                // 클라이언트가 받은 메시지를 유저들의 sBuffer에 각각 복사
                Array.Copy(rBuffer, one.sBuffer, rBuffer.Length);

                Console.WriteLine("{0}님에게 받은데이터 전송", one.client.Handle);

                // 각각의클라이언트소켓은 자신의 버퍼에 담고 있는 메시지를 전송한다.
                one.client.Send(one.sBuffer);

                one.ClearSendBuffer();
            }

            ClearReceiveBuffer();
            ClearSendBuffer();

            client.BeginReceive(rBuffer, 0, rBuffer.Length, SocketFlags.None, ReceiveCallBack, _userlist);
        }
    }



    class Program
    {
        static Socket listenSock;           // 접속을 처리할 소켓
        static string strIp = "192.168.60.230";
        static int port = 8082;
        static Thread t1;

        static List<User> userlist = new List<User>();

        static void Main(string[] args)
        {
            listenSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(strIp), port);

            listenSock.Bind(ip);
            Console.WriteLine("Bind()");
            listenSock.Listen(1000);
            Console.WriteLine("Listen()");

            // 스레드 생성
            t1 = new Thread(new ThreadStart(newClient));
            t1.Start();

            t1.Join();
            t1.Interrupt();
        }

        static void newClient()
        {
            while (true)
            {
                listenSock.BeginAccept(AcceptCallBack, null);
                Thread.Sleep(10);
            }
        }

        static void AcceptCallBack(IAsyncResult ar)
        {
            Socket client = listenSock.EndAccept(ar);

            User user = AddUser(client);

            listenSock.BeginAccept(AcceptCallBack, null);

            // 접속한 클라이언트 에게 메시지를 전송
            string Message = "Welcome To Game !!!";
            //문자열을 바이트 배열로 변환
            byte[] data = Encoding.Default.GetBytes(Message);
            client.Send(data);

            client.BeginReceive(user.rBuffer, 0, user.rBuffer.Length, SocketFlags.None, user.ReceiveCallBack, userlist);
        }


        static User AddUser(Socket _sock)
        {
            User user = new User(_sock);
            userlist.Add(user);
            return user;
        }

        static void CloseUser(Socket _sock)
        {
            User findUser = userlist.Find(o => (o.client.Handle == _sock.Handle));
            if (findUser != null)
            {
                findUser.CloseUser();
                userlist.Remove(findUser);
            }
        }
    }
}
