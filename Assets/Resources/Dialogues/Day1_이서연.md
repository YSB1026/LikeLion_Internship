## NODE: START
type: CHOICE
speaker: 이서연
emotion: anxious
trust_delta: 0

……무슨 일로 오셨죠? 실험실 상황은 보시다시피 엉망이에요. 
박 소장님이 그렇게 되신 건 유감이지만, 저도 지금 제정신이 아니거든요.

- [박준호 연구원과 사이가 좋았나요?] -> RELATION
- [사건 당시 어디에 있었는지 말해주세요.] -> ALIBI
- [당신이 장비를 조작한 건 아닙니까?] -> DEFENSE

## NODE: RELATION
type: FIXED
speaker: 이서연
emotion: uneasy
trust_delta: 1
next: END

안 좋았다기보단… 실망했죠. 
존경했던 분인데 최근 실험 결과에 집착하시는 모습이 좀 그랬거든요. 
그래도 죽을 만큼 미워하진 않았어요. 정말이에요.

## NODE: ALIBI
type: FIXED
speaker: 이서연
emotion: neutral
trust_delta: 0
next: ALIBI_AI

전 복도에 있었어요. 실험실로 들어가려는데 최민석 씨랑 소장님이 언쟁하는 소리가 들려서… 
잠시 기다리고 있었죠. 그때 갑자기 소리가 들린 거예요.

## NODE: ALIBI_AI
type: AI
speaker: 이서연
ai:role:npcweight:0.4
next: END

당시 들었던 언쟁의 분위기를 설명합니다. 
플레이어가 공감하면 최민석이 평소와 달리 강압적이었다는 힌트를 제공합니다.

## NODE: DEFENSE
type: FIXED
speaker: 이서연
emotion: angry
trust_delta: -2
next: END

지금 저를 의심하시는 거예요? 제가 왜요! 
장비 설정은 최민석 씨 담당이에요. 전 그저 보조였을 뿐이라고요!

## NODE: END
type: END
speaker: 이서연
emotion: neutral
trust_delta: 0

…더 물어보실 게 없다면 전 이만 가봐도 될까요?