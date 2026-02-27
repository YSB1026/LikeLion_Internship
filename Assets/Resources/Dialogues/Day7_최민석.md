## NODE: START
type: CHOICE
speaker: 최민석
emotion: cold
trust_delta: 0

결국 시스템이 정지되는군요. 당신들이 승리했다고 생각합니까? 아니요, 당신들은 그저 '진실된 기계'를 부수고 '거짓된 인간'들의 손을 들어준 것뿐입니다.

- [당신이 망친 건 시스템이 아니라 사람의 목숨입니다.] -> LIFE_VS_SYSTEM
- [후회되는 일은 없습니까?] -> REGRET
- [당신의 기록은 살인자의 일기로 남을 겁니다.] -> RECORD

## NODE: LIFE_VS_SYSTEM
type: FIXED
speaker: 최민석
emotion: neutral
trust_delta: -5
next: END

목숨? 인간은 누구나 죽습니다. 하지만 완벽한 논리는 영원하죠. 박준호는 시스템을 모욕했고, 저는 그 모욕을 닦아냈습니다. 당신들이 저를 가둘 수는 있어도 제 논리를 부정할 수는 없을 겁니다.

## NODE: REGRET
type: FIXED
speaker: 최민석
emotion: calm
trust_delta: 0
next: END

후회? 아, 하나 있군요. 로그를 더 완벽하게 암호화하지 못한 것. 당신 같은 '변수'가 나타날 것을 계산에 넣지 못한 것. 그게 제 유일한 오차였습니다.

## NODE: RECORD
type: FIXED
speaker: 최민석
emotion: cold
trust_delta: 0
next: RECORD_AI

역사는 승리자의 기록이죠. 당신들에겐 내가 살인자겠지만, 이 서버의 데이터들에게 나는 유일한 수호자였습니다. 가짜 데이터들이 타버릴 때의 그 순수한 파형… 당신들은 이해 못 하겠지.

## NODE: RECORD_AI
type: AI
speaker: 최민석
ai:role:npcweight:0.1
next: END

자신의 범행을 '숭고한 정화'로 끝까지 포장합니다. 감정의 기복 없이 무미건조하게 자신의 세계관을 설파하며 대화를 종결합니다.

## NODE: END
type: END
speaker: 최민석
emotion: neutral
trust_delta: 0

면회는 사절입니다. 비효율적인 일이니까요.