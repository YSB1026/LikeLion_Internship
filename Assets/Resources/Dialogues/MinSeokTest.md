## NODE: START
type: FIXED
speaker: 최민석
emotion: neutral
trust_delta: 0
next: FIRST_CHOICE

시스템 점검 결과는 이상이 없습니다.
계속 문제가 발생한다면 로그를 확인해야 합니다.

## NODE: FIRST_CHOICE
type: CHOICE
speaker: 최민석

- [사고 원인을 알 수 있나요?] -> INCIDENT
- [박준호 연구원과 관련 있나요?] -> RELATION
- [정확한 시스템 상태를 설명해주세요.] -> STATUS

## NODE: INCIDENT
type: FIXED
speaker: 최민석
emotion: serious
trust_delta: 0
next: END

정확한 원인은 로그 분석 후에야 판단 가능합니다.

## NODE: RELATION
type: FIXED
speaker: 최민석
emotion: neutral
trust_delta: 0
next: END

박준호 연구원과는 시스템 관련 논의만 있었습니다.

## NODE: STATUS
type: FIXED
speaker: 최민석
emotion: neutral
trust_delta: 0
next: END

현재 시스템은 정상 작동 중이며,
비정상적인 기록은 발견되지 않았습니다.

## NODE: END
type: FIXED
speaker: 최민석
emotion: neutral
trust_delta: 0

추가 질문이 있으면 알려주세요.
