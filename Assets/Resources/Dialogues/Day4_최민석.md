## NODE: START
type: CHOICE
speaker: 최민석
emotion: annoyed
trust_delta: 0

출입 기록이라니요. 그 데이터는 신뢰도가 낮습니다. 가끔 센서 오작동으로 기록이 누락되거나 지연되기도 하죠. 고작 그런 걸로 저를 서버실에 없었다고 몰아세우는 겁니까?

- [서버실에 없었다면, 누가 당신 계정으로 로그를 수정한 거죠?] -> WHO_ACCESSED
- [소장님께 '당신이 멈추게 될 거다'라고 경고한 적이 있죠?] -> THREATEN
- [권한 축소에 대한 보복으로 시스템을 조작한 것 아닙니까?] -> REVENGE

## NODE: WHO_ACCESSED
type: FIXED
speaker: 최민석
emotion: neutral
trust_delta: -2
next: WHO_AI

원격 접속의 가능성도 배제할 수 없습니다. 제가 제어실에서 모니터링하면서 서버에 명령을 내린 기록일 겁니다. 굳이 서버실 안에 있어야만 수정이 가능한 건 아니니까요.

## NODE: WHO_AI
type: AI
speaker: 최민석
ai:role:npcweight:0.2
next: END

기술적인 궤변을 늘어놓으며 원격 접속의 정당성을 강변합니다. 하지만 플레이어가 구체적인 네트워크 포트 기록을 압박하면 평소의 평정심을 잃고 신경질적인 반응을 보입니다.

## NODE: THREATEN
type: FIXED
speaker: 최민석
emotion: calm
trust_delta: -1
next: END

그건 경고가 아니라 '예측'이었습니다. 비논리적인 설계는 반드시 파멸을 부르니까요. 전 시스템의 대변자로서 사실을 말했을 뿐입니다. 결과적으로 제 예측이 맞았군요.

## NODE: REVENGE
type: FIXED
speaker: 최민석
emotion: angry
trust_delta: -3
next: END

보복? 고작 그런 유치한 감정 때문에 제 완벽한 시스템을 망가뜨렸을 거라고 생각합니까? 당신은 저를 너무 모르는군요. 전 시스템을 '치료'하려 했을 뿐입니다.

## NODE: END
type: END
speaker: 최민석
emotion: neutral
trust_delta: 0

쓸데없는 추측으로 제 시간을 뺏지 마십시오.