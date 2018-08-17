# DolDam1

Doldam 폴더가 프로젝트 폴더입니다.  
keystore암호는 doldam  
Dol.apk 가 실행파일입니다  
모바일 빌드할 땐 GameMamager의 GameManager.testEnvironment를 MOBILE로 설정해야합니다.  
(pc에서 테스트 할땐 PC로 설정)  


20180714 19:23 이영진  
1.피버모드 관련된 사항들 모두 적용함  
2.인스펙터뷰에서 수치를 조정할 수 있도록 함  
3.앞으로 pc에서 테스트 할 때 Hierarchy의 GameManager 오브젝트의 GameManager.testEnvironment를 pc로 하고, 모바일 빌드를 할땐 mobile로 설정함  
4.UI는 해상도에 따라 스케일링 되도록 함  


20180708 12:39 이영진  
1.눈덩이 크기와 속도 유기적으로 변경됨  
2.앞으로 pc에서 테스트할 때 주석처리 대신 InputLeft,InputRight를 InputLeftPC,InputRightPC로 바꾸면됨(PlayerMove.MoveAndRotate())  
3.양쪽 바깥으로 못나가게 막음  
4.장애물에 부딛히면 크기가 반으로 줄고 이펙트 생김  


20180705 20:58 이영진  
1.눈덩이 이미지 변경  
2.앞으로 apk를 추출할 때 주석처리해야하는 부분이 있음 (PlayerMove)


20180704 20:19 이영진  
1.눈덩이 속도와 크기가 갈수록 커짐  
2.장애물에 부딛히면 작아지고 느려짐  
3.UI시작할 수 있게 GameState를 만들고 일시정지를 만듬 (GameManager의 GameState)  
4.이젠 왼쪽을 터치하면 왼쪽으로, 오른쪽을 터치하면 오른쪽으로 감  
5.화면 위쪽을 터치하면 강제로 빨라지고 공이 커지게할 수 있고, 아래쪽을 터치하면 느려지고 공이 작아짐.  


20180702 01:47 이영진  
1.플레이어 이동 방향키로 일단 만들었음  
2.장애물 생성 및 충돌 만들었음  


20180814 16:42 박소현
1. 효과음 및 배경음 추가를 위한 SoundManager를 생성
2. StartScene에서 Button Event를 위한 스크립트 ButtonControl작성
3. SetUpScene에서 정수배로 효과음 및 배경음 조절가능하도록 Slider 설정
4. 일시정지 버튼을 눌렀을 때 Resume의 경우 GameManager의 GameState를 사용해서 다시 시작하도록 함.
하지만 Restart와 MainMenu 버튼의 경우 단순히 LoadScene으로 할 경우 GameManager와 SoundManager가 초기화가 안 되서 게임에서 오류 발생.
(금요일 까지 수정예정)


20180817 15:16 박소현
1. 일시정지 버튼 누르고 Resume과 Main Menu 버튼을 눌렀을 때 게임이 실행되지 않는 문제 해결
2. LoadScene을 한 뒤에 Game Manager가 panel을 찾지 못하는 문제 발생