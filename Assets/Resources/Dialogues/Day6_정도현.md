## NODE: START
type: CHOICE
speaker: 정도현
emotion: neutral
trust_delta: 0

세상에, 최민석이 비상 레버까지 막았다니… 그건 명백한 살인이군요. 조사관님, 저는 정말 상상도 못 했습니다. 두 사람이 그렇게까지 극단적인 관계였을 줄이야. 저는 그저 업무 효율을 위해 편의를 봐준 것뿐인데, 결과가 이렇게 되니 참담합니다.

- [당신이 최민석에게 준 '무제한 권한'이 이 살인을 가능케 했습니다.] -> RESPONSIBILITY_ADMIN
- [박 소장의 데이터 조작을 당신이 묵인한 증거도 찾았습니다.] -> CONNIVANCE_PROOF
- [검찰에 제출할 최종 보고서에 당신의 이름을 어떻게 적을까요?] -> FINAL_REPORT

## NODE: RESPONSIBILITY_ADMIN
type: FIXED
speaker: 정도현
emotion: uneasy
trust_delta: -1
next: ADMIN_AI

권한을 준 건 맞습니다만, 그걸 살인에 쓸 줄 누가 알았겠습니까? 칼을 쥐여줬더니 요리는 안 하고 사람을 찌른 격인데, 칼을 준 사람을 탓하는 건 가혹하지 않습니까?

## NODE: ADMIN_AI
type: AI
speaker: 정도현
ai:role:npcweight:0.4
next: END

자신은 최민석의 '기술적 사기'에 당한 선의의 관리자임을 강조합니다. 어떻게든 법적 책임을 회피하기 위해 비굴한 태도로 일관하며 협조를 약속합니다.

## NODE: CONNIVANCE_PROOF
type: FIXED
speaker: 정도현
emotion: anxious
trust_delta: -2
next: END

그건… 조작인 줄 몰랐습니다! 전 그저 성공적인 실험 결과가 필요했을 뿐이에요. 연구소에 투자가 들어와야 다 같이 먹고살 거 아닙니까? 제가 조작을 도운 게 아니라, 저도 속은 거라니까요!

## NODE: FINAL_REPORT
type: FIXED
speaker: 정도현
emotion: neutral
trust_delta: 0
next: END

조사관님, 우리 사이에 이럴 필요 없지 않습니까. 최민석이라는 명확한 범인이 있는데 굳이 관리 부실까지 크게 키워서 연구소를 닫게 해야겠습니까? 적당히… 좋게 좋게 갑시다.

## NODE: END
type: END
speaker: 정도현
emotion: neutral
trust_delta: 0

현명한 판단을 기다리겠습니다. 조사관님.