## NODE: START
type: CHOICE
speaker: 이서연
emotion: anxious
trust_delta: 0

그… 서랍 속에서 찾은 그 서류, 진짜인가요? 박 소장님이 데이터 수치를 직접 수정하라고 지시한 기록 말이에요. 전… 전 그냥 시키는 대로 했을 뿐인데, 이제 다 끝난 건가요?

- [당신이 이 수치들을 직접 수정한 건가요?] -> ADMIT_FRAUD
- [최민석 씨가 이 조작 사실을 알고 있었나요?] -> CHOI_KNOWLEDGE
- [당신은 이 사고가 일어날 줄 알고 있었죠?] -> PREDICTION

## NODE: ADMIT_FRAUD
type: FIXED
speaker: 이서연
emotion: crying
trust_delta: 1
next: ADMIT_AI

소장님이 시키셨어요! 결과가 안 나오면 투자가 끊길 거라고… 하지만 전 기계를 만질 줄은 몰라요. 전 숫자만 바꿨을 뿐이고, 기계 안전 장치는 분명 작동할 줄 알았다고요!

## NODE: ADMIT_AI
type: AI
speaker: 이서연
ai:role:npcweight:0.5
next: END

자신의 무죄를 주장하며 감정적으로 호소합니다. 본인이 관여한 데이터 조작이 사고로 이어질 줄은 꿈에도 몰랐다며 최민석의 '로그 관리'에 의문을 제기합니다.

## NODE: CHOI_KNOWLEDGE
type: FIXED
speaker: 이서연
emotion: uneasy
trust_delta: 0
next: END

최민석 씨는 귀신같은 사람이에요. 소장님이 수치를 건드리는 걸 몰랐을 리 없어요. 그런데도 그날 사고 직전까지 아무 말도 안 하다가… 갑자기 서버실에서 혼자 뭘 하고 있었던 걸까요?

## NODE: PREDICTION
type: FIXED
speaker: 이서연
emotion: anxious
trust_delta: -2
next: END

아니요! 사고가 날 줄 알았다면 제가 그 근처에 있었겠어요? 저도 죽을 뻔했다고요! 이건 누군가 의도적으로 안전 장치를… 아, 아니에요. 더는 말 못 하겠어요.

## NODE: END
type: END
speaker: 이서연
emotion: neutral
trust_delta: 0

전… 전 그냥 시키는 대로만 했을 뿐이에요. 제발 믿어주세요.