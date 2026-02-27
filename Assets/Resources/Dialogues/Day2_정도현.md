## NODE: START
type: CHOICE
speaker: 정도현
emotion: neutral
trust_delta: 0

조사가 길어지니 연구원들이 동요하고 있습니다. 조사관님, 이 일은 연구소의 명예가 걸린 문제입니다. 확실치 않은 정황으로 사람들을 몰아세우지 마시길 부탁드립니다.

- [전날 안전 점검 보고서, 사실 형식적인 것 아니었나요?] -> REPORT
- [박 소장님이 실험 결과를 조작했다는 의혹에 대해 아십니까?] -> FRAUD
- [두 연구원 사이에 심각한 문제가 있었다는 걸 알고 계셨죠?] -> FRICTION

## NODE: REPORT
type: FIXED
speaker: 정도현
emotion: uneasy
trust_delta: -1
next: REPORT_AI

형식적이라니요, 말이 심하시군요. 물론 인력이 부족해 점검이 평소보다 빠르게 진행되었을 수는 있습니다. 하지만 그게 사고의 직접적인 원인이라고 단정할 수는 없지 않습니까?

## NODE: REPORT_AI
type: AI
speaker: 정도현
ai:role:npcweight:0.4
next: END

점검 생략 지시 의혹에 대해 장황하게 변명합니다. 조직 운영의 어려움을 토로하며 플레이어의 이해를 구하는 태도를 보입니다.

## NODE: FRAUD
type: FIXED
speaker: 정도현
emotion: neutral
trust_delta: 0
next: END

소장님의 열정이 과했던 건 압니다. 하지만 조작이라니, 그건 고인에 대한 모독입니다. 증거가 없는 이야기는 연구소 차원에서 강력히 대응할 수밖에 없습니다.

## NODE: FRICTION
type: FIXED
speaker: 정도현
emotion: calm
trust_delta: 1
next: END

전문가들 사이의 의견 차이는 어디에나 있습니다. 최 연구원은 원칙주의자고, 소장님은 목표 지향적이었죠. 그 정도의 마찰이 살의로 이어진다는 건 지나친 억측입니다.

## NODE: END
type: END
speaker: 정도현
emotion: neutral
trust_delta: 0

원만한 해결을 바랍니다. 조사가 너무 오래 걸리지 않았으면 좋겠군요.