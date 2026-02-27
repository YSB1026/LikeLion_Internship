## NODE: START
type: CHOICE
speaker: 정도현
emotion: crying
trust_delta: 0

이럴 수는 없어… 내 25년 인생이 이렇게 끝날 수는 없다고! 조사관님, 제가 말씀드렸잖아요. 전 몰랐다고요! 최민석이 저렇게 미친놈일 줄 누가 알았겠습니까!

- [당신의 방조가 최민석에게 확신을 주었습니다.] -> ASSIST
- [연구소는 이제 공식적으로 폐쇄됩니다.] -> CLOSURE
- [마지막으로 박 소장님께 할 말은 없나요?] -> TO_PARK

## NODE: ASSIST
type: FIXED
speaker: 정도현
emotion: angry
trust_delta: -2
next: END

방조라니! 난 최선을 다해 조직을 관리한 것뿐이야! 당신이 내 위치에 있어 봐, 그 상황에서 실험을 멈추고 투자를 포기할 수 있었을 것 같아? 난 우리 모두를 위해 그런 거야!

## NODE: CLOSURE
type: FIXED
speaker: 정도현
emotion: crying
trust_delta: 0
next: END

내 퇴직금… 내 명예… 다 날아갔어. 이제 와서 누굴 탓하겠어. 하지만 조사관님, 정말 너무하시는군요. 조금만 눈감아줬으면 우리 모두 행복했을 텐데.

## NODE: TO_PARK
type: FIXED
speaker: 정도현
emotion: uneasy
trust_delta: 0
next: TO_PARK_AI

박 소장… 미안하네. 하지만 자네도 잘한 건 없지 않나. 자네가 조작만 안 했어도… 아니, 아니야. 죽은 사람한테 무슨 말을 하겠나. 다 지긋지긋해.

## NODE: TO_PARK_AI
type: AI
speaker: 정도현
ai:role:npcweight:0.4
next: END

책임을 고인에게 떠넘기려다 결국 자신의 무능함을 자인하는 비굴한 모습을 보입니다. 끝까지 반성보다는 손실에 대한 한탄을 늘어놓습니다.

## NODE: END
type: END
speaker: 정도현
emotion: neutral
trust_delta: 0

나중에… 변호사를 통해서 얘기합시다.