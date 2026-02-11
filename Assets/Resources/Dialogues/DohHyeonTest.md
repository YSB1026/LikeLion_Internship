## NODE: START
type: FIXED
speaker: 정도현
emotion: calm
trust_delta: 0
next: FIRST_CHOICE

사건과 관련하여 모든 절차는 규정대로 진행 중입니다.
하지만 일부 정보는 공개할 수 없습니다.

## NODE: FIRST_CHOICE
type: CHOICE
speaker: 정도현

- [사건 조사 상황을 알려주세요.] -> INVESTIGATION
- [연구원들의 책임 범위는?] -> RESPONSIBILITY
- [보고서를 확인할 수 있나요?] -> REPORT

## NODE: INVESTIGATION
type: FIXED
speaker: 정도현
emotion: cautious
trust_delta: 0
next: END

조사 진행 상황은 제한적으로만 공유할 수 있습니다.

## NODE: RESPONSIBILITY
type: FIXED
speaker: 정도현
emotion: cautious
trust_delta: 0
next: END

각 연구원의 책임 범위는 내부 규정에 따라 평가됩니다.

## NODE: REPORT
type: FIXED
speaker: 정도현
emotion: neutral
trust_delta: 0
next: END

공식 보고서는 보안 문제로 외부 열람이 불가합니다.

## NODE: END
type: FIXED
speaker: 정도현
emotion: neutral
trust_delta: 0

추가 문의가 있으면 알려주세요.
