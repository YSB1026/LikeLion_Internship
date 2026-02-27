## NODE: START
type: CHOICE
speaker: 최민석
emotion: calm
trust_delta: 0

시스템 담당자 최민석입니다. 로그 조사는 이미 끝났을 텐데요. 
기계적인 결함은 발견되지 않았습니다. 질문하시죠.

- [장비 설정을 마지막으로 만진 사람이 누구죠?] -> SETTING
- [이서연 씨가 당신과 소장님의 언쟁을 들었다던데.] -> ARGUE
- [사고 당시 제어실에서 무엇을 했습니까?] -> CONTROL

## NODE: SETTING
type: FIXED
speaker: 최민석
emotion: neutral
trust_delta: 0
next: SETTING_AI

로그상으론 저입니다. 하지만 모든 조정은 규정 내에서 이루어졌습니다. 
수치 변경은 실험 효율을 위한 합리적인 선택이었습니다.

## NODE: SETTING_AI
type: AI
speaker: 최민석
ai:role:npcweight:0.3
next: END

시스템 로그의 정당성을 짧고 간결하게 재진술합니다. 
반복 질문 시 "이미 답변드린 사항입니다"라며 논리적으로 방어합니다.

## NODE: ARGUE
type: FIXED
speaker: 최민석
emotion: annoyed
trust_delta: -1
next: END

이서연 씨는 감정적으로 판단하는 경향이 있죠. 
업무상 의견 조율이었을 뿐입니다. 그걸 언쟁이라 부르는 건 비약입니다.

## NODE: CONTROL
type: FIXED
speaker: 최민석
emotion: calm
trust_delta: 0
next: END

실험 수치를 모니터링하고 있었습니다. 이상 징후는 없었습니다. 
사고는 예측 불가능한 물리적 변수로 발생한 것입니다.

## NODE: END
type: END
speaker: 최민석
emotion: neutral
trust_delta: 0

필요한 로그 데이터가 있다면 서면으로 요청하십시오.