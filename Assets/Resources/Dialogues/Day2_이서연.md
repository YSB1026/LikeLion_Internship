## NODE: START
type: CHOICE
speaker: 이서연
emotion: anxious
trust_delta: 0

어제 이후로 잠을 한숨도 못 잤어요. 연구소 복도를 지날 때마다 그날 들었던 비명 소리가 들리는 것 같아서……. 저한테 뭘 더 원하시는 거죠?

- [박 소장님이 실험 결과를 조작했다는 소문이 있던데요.] -> MANIPULATION
- [사고 직전 들었던 최민석 씨와의 언쟁, 구체적으로 어떤 내용이었나요?] -> ARGUE_DETAIL
- [당신도 그 실험의 일원이었으니 책임이 있지 않나요?] -> RESPONSIBILITY

## NODE: MANIPULATION
type: FIXED
speaker: 이서연
emotion: cautious
trust_delta: 1
next: MANIPULATION_AI

조작이라니요, 누가 그런 말을……. 하지만 소장님이 최근에 수치 문제로 예민하셨던 건 사실이에요. 데이터가 생각만큼 안 나온다고 최민석 씨를 닦달하시기도 했고요.

## NODE: MANIPULATION_AI
type: AI
speaker: 이서연
ai:role:npcweight:0.5
next: END

소장의 압박에 대해 조심스럽게 언급합니다. 공감하면 본인이 데이터 정리에 일부 관여하며 느꼈던 위질감을 털어놓기 시작합니다.

## NODE: ARGUE_DETAIL
type: FIXED
speaker: 이서연
emotion: uneasy
trust_delta: 0
next: END

소장님은 '일정을 맞춰라'라고 하셨고, 최민석 씨는 '시스템 한계'라고 맞섰어요. 평소엔 최민석 씨가 그냥 넘겼을 텐데, 그날은 유독 차갑게 대꾸하더라고요. 마치 뭔가 준비라도 한 사람처럼요.

## NODE: RESPONSIBILITY
type: FIXED
speaker: 이서연
emotion: crying
trust_delta: -2
next: END

제가 뭘 할 수 있었겠어요! 전 시키는 대로 데이터를 정리했을 뿐이에요. 보고서에 제 이름이 올라가긴 했지만, 그건 소장님 결정이었단 말이에요!

## NODE: END
type: END
speaker: 이서연
emotion: neutral
trust_delta: 0

제발 전 빼주세요. 전 정말 아무것도 몰라요.