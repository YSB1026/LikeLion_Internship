## NODE: START
type: CHOICE
speaker: 이서연
emotion: uneasy
trust_delta: 0

조사관님, 어젯밤에 곰곰이 생각해 봤어요. 제가 숨긴다고 해결될 일이 아니더라고요. 사실… 사고 당일 아침에 두 사람이 싸우는 걸 넘어서, 최민석 씨가 소장님께 '당신 방식대로라면 기계가 멈추는 게 아니라 당신이 멈추게 될 거다'라고 말하는 걸 들었어요.

- [그 말을 들었을 때 소장님의 반응은 어땠나요?] -> PARK_REACTION
- [최민석 씨가 그런 말을 한 이유가 뭐라고 생각해요?] -> CHOI_MOTIVE
- [왜 이제서야 그 사실을 말하는 거죠?] -> WHY_NOW

## NODE: PARK_REACTION
type: FIXED
speaker: 이서연
emotion: anxious
trust_delta: 1
next: END

소장님은 비웃으셨어요. '네가 감히 내 설계를 평가하려 드냐'면서요. 최민석 씨는 아무 말 없이 소장님을 빤히 쳐다보다가 서버실로 들어갔는데, 그 눈빛이… 정말 소름 끼쳤어요.

## NODE: CHOI_MOTIVE
type: FIXED
speaker: 이서연
emotion: cautious
trust_delta: 0
next: MOTIVE_AI

최민석 씨는 자신의 시스템이 더럽혀지는 걸 못 견뎌 했어요. 소장님이 수치를 조작하는 게 시스템의 '순수성'을 망친다고 생각했던 것 같아요. 그는 사람이 아니라 기계를 사랑하는 사람이었으니까요.

## NODE: MOTIVE_AI
type: AI
speaker: 이서연
ai:role:npcweight:0.6
next: END

최민석의 결벽증적인 성격과 박 소장의 무리한 지시가 충돌했던 지점을 설명합니다. 플레이어가 동조하면 최민석이 평소에 시스템 보안을 구실로 얼마나 많은 권한을 독점했는지 털어놓습니다.

## NODE: WHY_NOW
type: FIXED
speaker: 이서연
emotion: crying
trust_delta: -1
next: END

무서웠으니까요! 최민석 씨가 로그를 다 쥐고 있는데, 제가 섣불리 말했다가 제 기록까지 조작해서 저를 범인으로 만들면 어떡해요? 하지만 이젠 상관없어요. 진실이 더 무서워졌거든요.

## NODE: END
type: END
speaker: 이서연
emotion: neutral
trust_delta: 0

제 말이 도움이 됐으면 좋겠네요. 정말이에요.