## NODE: START
type: CHOICE
speaker: 최민석
emotion: calm
trust_delta: 0

이틀째군요. 반복되는 질문은 시간 낭비일 뿐입니다. 어제 말씀드렸듯 모든 시스템 수치는 기록되어 있고, 제 행동엔 논리적 근거가 있습니다.

- [박 소장님이 당신의 권한을 축소하려 했다면서요?] -> AUTHORITY
- [이서연 씨는 당신이 사고 직후 기괴한 표정을 지었다고 하더군요.] -> EXPRESSION
- [실험 로그에 지연 시간이 발생한 이유가 뭡니까?] -> DELAY_LOG

## NODE: AUTHORITY
type: FIXED
speaker: 최민석
emotion: neutral
trust_delta: -1
next: AUTHORITY_AI

조직 내에서의 역할 조정은 흔한 일입니다. 소장님은 현장을 중시했고, 전 시스템의 안전을 중시했을 뿐이죠. 그걸 갈등으로 해석하는 건 이서연 씨다운 감상적인 발상입니다.

## NODE: AUTHORITY_AI
type: AI
speaker: 최민석
ai:role:npcweight:0.3
next: END

권한 축소에 대해 매우 냉담하게 반응합니다. 자신의 업무 능력을 과시하며, 권한 축소가 오히려 비합리적인 결정이었다고 주장합니다.

## NODE: EXPRESSION
type: FIXED
speaker: 최민석
emotion: annoyed
trust_delta: -2
next: END

기괴한 표정이라니요. 당황스러움을 그렇게 표현한 모양이군요. 눈앞에서 사람이 죽었는데 평정을 유지할 수 있는 사람이 몇이나 되겠습니까? 전 그저 상황을 수습하려 했을 뿐입니다.

## NODE: DELAY_LOG
type: FIXED
speaker: 최민석
emotion: calm
trust_delta: 0
next: END

데이터 처리량이 임계치를 넘으면 자연스럽게 발생하는 지연입니다. 물리 법칙을 제게 따지시면 곤란하죠. 로그에 찍힌 시간이 모든 것을 증명합니다.

## NODE: END
type: END
speaker: 최민석
emotion: neutral
trust_delta: 0

더 영양가 있는 질문이 생기면 다시 오십시오.