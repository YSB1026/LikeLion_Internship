## NODE: START
type: CHOICE
speaker: 최민석
emotion: angry
trust_delta: 0

그 기록을 어디서 찾았지? 아니, 그건 중요하지 않아. 비상 레버를 차단한 건 시스템이 오작동을 일으켜서 2차 피해를 막기 위한 표준 매뉴얼에 따른 조치였다! 내가 아니었으면 연구소 전체가 날아갔을 거란 말이다!

- [표준 매뉴얼 어디에도 생존자의 구조 신호를 무시하라는 조항은 없습니다.] -> MANUAL_LOGIC
- [당신은 소장님이 죽어가는 과정을 즐기며 지켜본 것 아닙니까?] -> ENJOY_MURDER
- [당신의 '완벽한 시스템'은 이제 살인 도구가 되었습니다.] -> SYSTEM_FAILURE

## NODE: MANUAL_LOGIC
type: FIXED
speaker: 최민석
emotion: angry
trust_delta: -2
next: MANUAL_AI

네가 뭘 알아! 과부하 상태에서 레버를 당기면 전력이 역류해서 메인 서버가 타버린다고! 박준호 그 인간 하나 때문에 내 8년의 기록이 담긴 시스템을 포기하라고? 그건 비합리적이야!

## NODE: MANUAL_AI
type: AI
speaker: 최민석
ai:role:npcweight:0.2
next: END

시스템 보호라는 명분 아래 자신의 살의를 정당화하려 궤변을 늘어놓습니다. 하지만 말투에서 점점 초조함과 광기가 묻어나오며 논리가 꼬이기 시작합니다.

## NODE: ENJOY_MURDER
type: FIXED
speaker: 최민석
emotion: cold
trust_delta: -3
next: END

즐겼냐고? 아니, 감상했다. 오류가 스스로의 과오에 의해 소멸되는 과정을 지켜보는 건… 지극히 교육적인 경험이었지. 그는 마지막 순간에야 깨달았을 거다. 숫자는 속일 수 있어도 시스템은 속일 수 없다는 걸.

## NODE: SYSTEM_FAILURE
type: FIXED
speaker: 최민석
emotion: crying
trust_delta: -5
next: END

살인 도구? 내 시스템이? 아니야… 내 시스템은 완벽했어. 오염된 부분을 도려낸 것뿐이야! 당신들이 뭔데 내 설계를 모욕해! 당신들도 박준호랑 똑같아!

## NODE: END
type: END
speaker: 최민석
emotion: angry
trust_delta: 0

꺼져! 내 시스템에서 당장 나가!