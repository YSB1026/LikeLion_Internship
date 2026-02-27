## NODE: START
type: CHOICE
speaker: 정도현
emotion: anxious
trust_delta: 0

미쳤어… 최민석, 자네 정말 제정신인가? 어떻게 그런 짓을 하고도 당당할 수 있어! 조사관님, 보셨죠? 저 친구는 괴물입니다! 전 정말로 저런 계획이 있었을 줄은 꿈에도 몰랐습니다!

- [최민석 씨가 권한 독점을 할 때 왜 제지하지 않았습니까?] -> NEGLECT
- [당신이 점검을 생략한 게 최민석에게 기회를 준 것 아닙니까?] -> OPPORTUNITY
- [이제 와서 선을 긋는다고 당신의 책임이 사라지진 않습니다.] -> RESPONSIBILITY_FINAL

## NODE: NEGLECT
type: FIXED
speaker: 정도현
emotion: uneasy
trust_delta: -1
next: NEGLECT_AI

그건… 전문가의 영역이니까요! 저는 행정적인 부분을 관리할 뿐이지, 저 친구가 코드 속에 살인 기계를 심어둘 줄 누가 알았겠습니까? 이건 전적으로 최민석의 단독 범행입니다!

## NODE: NEGLECT_AI
type: AI
speaker: 정도현
ai:role:npcweight:0.4
next: END

자신의 관리 소홀을 정당화하기 위해 비명을 지르듯 변명합니다. 연구소의 폐쇄를 막기 위해 모든 책임을 최민석 개인에게 몰아넣으려 필사적으로 매달립니다.

## NODE: OPPORTUNITY
type: FIXED
speaker: 정도현
emotion: anxious
trust_delta: -2
next: END

기회를 줬다니요! 전 그저 업무를 효율적으로 하려던 것뿐입니다! 최민석이 그걸 악용할 줄 알았다면 당장 해고했을 겁니다. 저도 피해자라고요, 저 미친놈 때문에 내 커리어가 끝장나게 생겼는데!

## NODE: RESPONSIBILITY_FINAL
type: FIXED
speaker: 정도현
emotion: neutral
trust_delta: 0
next: END

……조사관님, 제발 부탁입니다. 보고서에는 제가 최민석의 범행을 밝혀내는 데 협조했다고 써주십시오. 관리 소홀은 인정하겠습니다. 하지만 살인 방조는 아니에요.

## NODE: END
type: END
speaker: 정도현
emotion: neutral
trust_delta: 0

전… 이제 어떻게 되는 거죠? 연구소는… 우리 연구소는요?