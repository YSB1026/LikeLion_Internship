## NODE: START
type: CHOICE
speaker: 이서연
emotion: calm
trust_delta: 0

짐은 다 쌌어요. 이제 곧 경찰들이 오겠죠? 무섭긴 하지만… 차라리 마음은 편해요. 진실을 말하지 않고 평생 그 소리를 들으며 사는 것보다는 나을 테니까요.

- [당신의 증언이 결정적이었어요. 고마워요.] -> GRATITUDE
- [이제 이 연구소는 어떻게 될까요?] -> FUTURE
- [법정에서 당신의 과오도 다뤄질 겁니다.] -> JUDGEMENT

## NODE: GRATITUDE
type: FIXED
speaker: 이서연
emotion: neutral
trust_delta: 1
next: END

고마워하실 것 없어요. 전 영웅이 아니니까요. 그저… 너무 늦지 않게 사람으로 남고 싶었을 뿐이에요. 조사관님이 아니었다면 전 평생 저 자신을 속이며 살았겠죠.

## NODE: FUTURE
type: FIXED
speaker: 이서연
emotion: neutral
trust_delta: 0
next: END

폐쇄되겠죠. 조작과 살인이 일어난 곳에 누가 다시 오겠어요? 하지만 괜찮아요. 가짜 데이터로 쌓아 올린 성은 무너지는 게 맞으니까요. 이제 진짜 제 인생을 찾아보려고요.

## NODE: JUDGEMENT
type: FIXED
speaker: 이서연
emotion: calm
trust_delta: 0
next: END

알고 있어요. 제가 수치를 고쳤던 기록들, 소장님의 지시를 묵인했던 순간들… 다 감당할 거예요. 그게 소장님께 드릴 수 있는 마지막 예의겠죠.

## NODE: END
type: END
speaker: 이서연
emotion: neutral
trust_delta: 0

조사관님, 진실을 찾아주셔서… 정말 감사했어요.