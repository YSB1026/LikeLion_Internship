## NODE: START
type: CHOICE
speaker: 정도현
emotion: uneasy
trust_delta: 0

데이터 조작이라니요… 조사관님, 그게 사실이라면 이건 우리 연구소 전체의 존립이 걸린 문제입니다. 박 소장님이 독단적으로 그런 일을 벌였다는 증거가 확실합니까?

- [당신이 안전 점검을 생략 지시했다는 내부 폭로가 있습니다.] -> BYPASS_ORDER
- [데이터 조작을 알고도 묵인하신 것 아닌가요?] -> CONNIVANCE
- [이 사건을 사고로 종결하라고 연구원들을 압박했습니까?] -> PRESSURE

## NODE: BYPASS_ORDER
type: FIXED
speaker: 정도현
emotion: anxious
trust_delta: -2
next: BYPASS_AI

내부 폭로라니요! 그건 '효율적 자원 배분'이었습니다. 일정은 촉박하고 인력은 없는데, 서류 작업에만 매달릴 수는 없지 않습니까? 하지만 사고를 예견한 건 절대 아닙니다!

## NODE: BYPASS_AI
type: AI
speaker: 정도현
ai:role:npcweight:0.4
next: END

자신의 결정이 조직을 위한 최선이었음을 강변합니다. 책임 소재가 자신에게 넘어오려 하자 이서연이나 최민석의 평소 행실을 깎아내리며 주의를 돌립니다.

## NODE: CONNIVANCE
type: FIXED
speaker: 정도현
emotion: neutral
trust_delta: -1
next: END

전 운영을 담당할 뿐, 세부적인 연구 수치까지는 모릅니다. 소장님이 올린 보고서를 믿었을 뿐이죠. 관리자의 신뢰를 조작으로 갚다니… 박 소장님께 실망이 크군요.

## NODE: PRESSURE
type: FIXED
speaker: 정도현
emotion: calm
trust_delta: 0
next: END

압박이 아니라 '수습'입니다. 연구소가 폐쇄되면 여기 있는 모든 사람의 생계가 위태로워집니다. 전 우리 모두를 지키기 위해 최선을 다하고 있는 겁니다.

## NODE: END
type: END
speaker: 정도현
emotion: neutral
trust_delta: 0

진실도 중요하지만, 남은 사람들의 미래도 생각해주십시오.