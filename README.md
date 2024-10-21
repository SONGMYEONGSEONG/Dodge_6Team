# Dodge 게임 제작
SSC_Unity_6기_게임개발 입문 프로젝트

### [프로젝트 소개]
![1Title](https://github.com/user-attachments/assets/a0ba9727-08ab-4e99-896e-d0078e10a282)


스타코일 : 끝없는 공격

우주 전쟁..
그들로부터 벗어나지만 결국 벗어나지 못한 이야기.
이것은 당신의 죽음에 관한 이야기이다.

개발환경 - Unity2D, C#, Visual Studio

---
### [프로젝트 목표]
- 팀원과의 협업을 통해 게임 개발하기
- 필수 기능과 도전 기능을 전부 구현하기
- 강의에서 들은 구조를 최대한 활용해서 설계하기

---
### [개발 기간]
2024.10.15 - 2024.10.22 (7일)

---
### [Funtion]
#### 1.캐릭터 이동과 공격 & 로컬 멀티 플레이 가능(2P까지)
![2플레이어 이동 및 공격](https://github.com/user-attachments/assets/297f677e-dc06-4007-82e0-f51d242df07f)
![3로컬멀티플레이가능](https://github.com/user-attachments/assets/efe7e05d-4d62-4618-aa35-e64520f11f5b)

1P : WASD(상하좌우) - 캐릭터 이동 , 마우스 좌클릭 - 캐릭터 공격
2P : 방향키(상하좌우) - 캐릭터 이동 , 스페이스 바 - 캐릭터 공격

게임 시작시 Life 3개가 주어지며 적 기체 또는 총알에 맞으면 Life가 1감소됩니다.
2P로 시작할경우 Life는 공동으로 사용되며 Life는 6으로 시작하게 됩니다.

---
#### 2. 아이템 추가
![image](https://github.com/user-attachments/assets/76abeeee-931b-470a-a4cf-d15d7e533e2d)
![image](https://github.com/user-attachments/assets/d413159a-2821-4457-b281-e7e68530b7aa)

Score 증가 아이템을 제외한 아이템들은 사용시 3초 동안 적용되며 3초가 지나면 해제 됩니다.

---
#### 3. 게임 시간이 흐름에 따라 난이도 증가
![image](https://github.com/user-attachments/assets/517e6622-8bdb-41b9-8343-6d2a51b82514)

게임 시간 15초가 지날떄마다 적들의 생성 주기가 짧아져 플레이어는 좀더 긴박한 플레이를 즐길 수 있습니다.

---
#### 4. 카메라 시점 처리
![image](https://github.com/user-attachments/assets/b7b1b39a-75e9-4166-8db3-b7820feb8716)

![4카메라시점처리](https://github.com/user-attachments/assets/134467fb-92dc-40f2-9e3b-34e2e192a779)

Scene뷰에서 배경은 이렇게 큰 화면으로 카메라가 벽 외부를 비칠수도 있으나
Cinemachine을 활용하여 카메라 범위 제한 처리를 하였습니다.

---
