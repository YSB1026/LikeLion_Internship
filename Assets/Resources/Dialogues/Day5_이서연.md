## NODE: START
type: CHOICE
speaker: 이서연
emotion: crying
trust_delta: 0

조사관님이 찾아낸 그 코드…… 최민석 씨가 정말로 소장님을 죽이려고 안전장치를 멈춘 건가요? 기계가 고장 난 게 아니라, 사람이 멈추게 한 거라고요? 세상에, 전 그런 사람과 같은 공간에 있었다니……

- [최민석 씨가 왜 이렇게까지 했다고 생각합니까?] -> MOTIVE_FINAL
- [박 소장님의 조작이 최민석 씨를 자극했을까요?] -> STIMULATION
- [당신이 알고 있는 마지막 비밀은 없나요?] -> LAST_SECRET

## NODE: MOTIVE_FINAL
type: FIXED
speaker: 이서연
emotion: angry
trust_delta: 1
next: END

그 사람은 완벽주의자였어요. 소장님이 데이터를 조작해서 가짜 결과를 만드는 걸 자기 시스템에 대한 '모욕'이라고 생각했을 거예요. 하지만 그렇다고 사람을 죽여요? 그건 정상이 아니에요!

## NODE: STIMULATION
type: FIXED
speaker: 이서연
emotion: uneasy
trust_delta: 0
next: STIMULATION_AI

네, 사고 전날 최민석 씨가 소장님 방에서 나오면서 '쓰레기 같은 데이터는 쓰레기통에 들어가야 한다'고 중얼거리는 걸 들었어요. 그 쓰레기통이 실험실 자체가 될 줄은 몰랐죠.

## NODE: STIMULATION_AI
type: AI
speaker: 이서연
ai:role:npcweight:0.6
next: END

최민석의 결벽증적인 성격과 박 소장의 비도덕적 행위가 충돌했던 순간들을 증언합니다. 범행의 동기가 단순한 보복이 아닌 '시스템 정화'라는 광기였음을 암시합니다.

## NODE: LAST_SECRET
type: FIXED
speaker: 이서연
emotion: anxious
trust_delta: -2
next: END

……사실 소장님이 조작을 지시할 때 최민석 씨의 접속 권한을 몰래 뺏으려던 걸 알고 있었어요. 소장님도 최민석 씨가 방해될 걸 알았던 거죠. 두 사람 다 멈췄어야 했어요.

## NODE: END
type: END
speaker: 이서연
emotion: neutral
trust_delta: 0

이제 다 끝난 거죠? 무서워서 더는 여기 못 있겠어요.