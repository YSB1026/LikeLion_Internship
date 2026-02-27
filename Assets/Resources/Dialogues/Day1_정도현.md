## NODE: START
type: CHOICE
speaker: 정도현
emotion: neutral
trust_delta: 0

운영 관리자로서 이번 불상사에 대해 깊은 유감을 표합니다. 
연구소의 안정이 최우선입니다. 조사가 조용하고 신속하게 마무리되길 바랍니다.

- [이번 실험의 안전 점검은 제대로 됐나요?] -> SAFETY
- [최민석 연구원에 대해 어떻게 생각하십니까?] -> ABOUT_CHOI
- [연구소 내부 분위기는 어땠습니까?] -> ATMOSPHERE

## NODE: SAFETY
type: FIXED
speaker: 정도현
emotion: neutral
trust_delta: 0
next: SAFETY_AI

서류상으로는 아무런 문제가 없었습니다. 관리자로서 정기 보고를 확인했고, 
모든 절차는 규정된 가이드라인 안에서 집행되었습니다. 그게 중요한 것 아니겠습니까?

## NODE: SAFETY_AI
type: AI
speaker: 정도현
ai:role:npcweight:0.4
next: END

조직의 책임 회피를 위해 말을 길게 늘어놓습니다. 
개인적인 실수보다는 시스템의 한계나 불운을 강조하며 본질을 흐립니다.

## NODE: ABOUT_CHOI
type: FIXED
speaker: 정도현
emotion: calm
trust_delta: 1
next: END

최 연구원 말입니까? 일은 정확하게 처리하는 친구죠. 비록 설명이 부족할 때가 있지만, 
시스템에 관해서는 우리 연구소에서 가장 신뢰할 만한 인물입니다.

## NODE: ATMOSPHERE
type: FIXED
speaker: 정도현
emotion: uneasy
trust_delta: -1
next: END

성과 중심의 분위기가 있었던 건 사실입니다. 박 소장님도 의욕이 넘치셨죠. 
하지만 그런 열정이 이런 비극으로 이어질 줄은 아무도 몰랐을 겁니다.

## NODE: END
type: END
speaker: 정도현
emotion: neutral
trust_delta: 0

절차에 어긋남이 없는지 다시 한번 검토해 주시기 바랍니다.