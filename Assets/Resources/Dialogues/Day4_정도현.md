## NODE: START
type: CHOICE
speaker: 정도현
emotion: cautious
trust_delta: 0

최민석 연구원의 기록에서 모순이 발견되었다고요? 세상에… 전 정말 그 친구를 믿었습니다. 일 처리가 워낙 깔끔해서 토를 달 이유가 없었거든요. 만약 그가 독단적으로 무언가를 건드렸다면, 그건 개인의 일탈입니다.

- [점검 생략 지시가 최 연구원의 요청 때문이었나요?] -> REQUEST_BY_CHOI
- [최민석 씨가 시스템 권한을 독점하도록 방치한 이유는 뭡니까?] -> MONOPOLY
- [연구소 차원에서 최민석 씨를 고발할 용의가 있습니까?] -> ACCUSE_CHOI

## NODE: REQUEST_BY_CHOI
type: FIXED
speaker: 정도현
emotion: uneasy
trust_delta: 1
next: REQUEST_AI

사실… 최 연구원이 그랬어요. '자기가 실시간으로 모니터링하고 있으니 육안 점검은 시간 낭비'라고요. 전 그 말을 믿고 효율성을 위해 점검을 간소화한 겁니다. 저도 속은 거예요!

## NODE: REQUEST_AI
type: AI
speaker: 정도현
ai:role:npcweight:0.4
next: END

자신은 최민석의 기술적 권위에 속아 넘어간 피해자임을 강조합니다. 최민석이 평소 얼마나 폐쇄적으로 정보를 관리했는지 비난하며 책임을 떠넘깁니다.

## NODE: MONOPOLY
type: FIXED
speaker: 정도현
emotion: neutral
trust_delta: 0
next: END

전문 인력이 부족한 상황에서 최 연구원 같은 베테랑에게 의존할 수밖에 없었습니다. 권한 독점이 아니라 '위임'이었죠. 그 위임된 신뢰를 그가 배신했을 줄은 꿈에도 몰랐습니다.

## NODE: ACCUSE_CHOI
type: FIXED
speaker: 정도현
emotion: calm
trust_delta: 1
next: END

증거만 확실하다면요. 우리 연구소의 명예를 실추시킨 자를 감쌀 이유는 없습니다. 조사관님, 필요한 데이터가 있다면 무엇이든 협조하겠습니다. 단, 제 책임에 대해서는 참작해주셔야 합니다.

## NODE: END
type: END
speaker: 정도현
emotion: neutral
trust_delta: 0

결국 진실은 드러나게 마련이군요. 저도 적극 돕겠습니다.