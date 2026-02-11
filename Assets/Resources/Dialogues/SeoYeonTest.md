## NODE: START
type: FIXED
speaker: 이서연
emotion: neutral
trust_delta: 0
next: FIRST_CHOICE

……무슨 일로 오셨죠?
지금 상황이 상황이라… 솔직히 좀 예민합니다.


## NODE: FIRST_CHOICE
type: CHOICE
speaker: 이서연

- [박준호 연구원과 사이가 좋았나요?] -> RELATION
- [사고 직전에 무슨 일이 있었죠?] -> INCIDENT
- [당신이 수상합니다.] -> ACCUSE


## NODE: RELATION
type: FIXED
speaker: 이서연
emotion: uneasy
trust_delta: 1
next: END

좋았다고 말하긴 어렵네요.
존경은 했지만… 실망도 컸어요.


## NODE: INCIDENT
type: FIXED
speaker: 이서연
emotion: anxious
trust_delta: 0
next: END

사고 직전에…
최민석 씨랑 언쟁하는 소리를 들었어요.
정확한 내용은 못 들었지만… 분위기가 심상치 않았습니다.


## NODE: ACCUSE
type: FIXED
speaker: 이서연
emotion: angry
trust_delta: -2
next: END

저를 의심하시는 건가요?
전 그 자리에 없었습니다.


## NODE: END
type: FIXED
speaker: 이서연
emotion: neutral
trust_delta: 0

…더 궁금한 게 있으면 다시 물어보세요.
