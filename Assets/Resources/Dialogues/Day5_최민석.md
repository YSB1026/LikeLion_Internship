## NODE: START
type: CHOICE
speaker: 최민석
emotion: calm
trust_delta: 0

결국 찾아내셨군요. 대단합니다. 하지만 오해하지 마십시오. 저는 살인을 한 게 아닙니다. 거짓으로 오염된 실험과, 그 오염을 주도한 '오류'를 제거했을 뿐입니다.

- [사람의 생명보다 시스템의 수치가 더 중요했습니까?] -> VALUE_SYSTEM
- [당신이 수정한 코드가 박 소장을 죽였습니다. 인정합니까?] -> CONFESSION
- [왜 스스로 신고하거나 멈추지 않았죠?] -> WHY_NOT_STOP

## NODE: VALUE_SYSTEM
type: FIXED
speaker: 최민석
emotion: cold
trust_delta: -3
next: VALUE_AI

박준호 소장은 과학자가 아니었습니다. 수치를 조작하는 순간 그는 이미 시스템의 적이었죠. 적을 제거하는 것은 관리자의 의무입니다. 결과는 깨끗하지 않습니까? 모든 조작된 데이터가 그와 함께 타버렸으니.

## NODE: VALUE_AI
type: AI
speaker: 최민석
ai:role:npcweight:0.2
next: END

자신의 행동을 '시스템 정화'라고 주장하며 소름 끼칠 정도로 차분하게 설명합니다. 죄책감은 전혀 보이지 않으며 플레이어의 윤리적 질문을 논리적으로 반박하려 합니다.

## NODE: CONFESSION
type: FIXED
speaker: 최민석
emotion: calm
trust_delta: -1
next: END

인정하죠. 안전 장치의 지연값을 수정한 건 저입니다. 하지만 소장님이 규정된 안전 지시를 어기고 현장에 무리하게 들어가지 않았다면 죽지 않았을 겁니다. 그는 자기 과욕에 죽은 겁니다.

## NODE: WHY_NOT_STOP
type: FIXED
speaker: 최민석
emotion: annoyed
trust_delta: -2
next: END

멈추다니요? 시스템이 거짓을 뱉어내고 있는데? 저는 관리자로서 가장 '합리적'인 결론을 내린 겁니다. 오류는 삭제되어야 하니까요. 당신도 조사관으로서 오류를 삭제하러 온 것 아닙니까?

## NODE: END
type: END
speaker: 최민석
emotion: neutral
trust_delta: 0

자, 이제 저를 어떻게 처리할 건지 결정하시죠. 논리적으로 말입니다.