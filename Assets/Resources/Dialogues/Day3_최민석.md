## NODE: START
type: CHOICE
speaker: 최민석
emotion: calm
trust_delta: 0

서버 백업 데이터에서 이상한 점이라도 찾으셨나 보군요. 하지만 말씀드렸을 텐데요. 로그는 결과물일 뿐입니다. 이미 일어난 물리적 현상을 기록할 뿐이죠.

- [안전 경고 발송이 왜 7분이나 지연되었죠?] -> LOG_DELAY
- [박 소장님이 데이터를 조작했다는 걸 이미 알고 있었죠?] -> KNOW_FRAUD
- [당신이 안전 장치 로그 접근 권한을 수정한 기록이 있습니다.] -> ACCESS_MOD

## NODE: LOG_DELAY
type: FIXED
speaker: 최민석
emotion: neutral
trust_delta: -1
next: DELAY_AI

네트워크 트래픽 과부하 현상입니다. 실험 장비에서 쏟아지는 원시 데이터를 처리하다 보면 지연은 흔히 발생합니다. 그걸 고의적이라고 의심하는 건 IT 기초 상식이 부족하신 겁니다.

## NODE: DELAY_AI
type: AI
speaker: 최민석
ai:role:npcweight:0.3
next: END

전문 용어를 섞어가며 지연 현상의 정당성을 주장합니다. 질문자의 논리적 허점을 파고들어 대화를 무의미하게 만드려 시도합니다.

## NODE: KNOW_FRAUD
type: FIXED
speaker: 최민석
emotion: calm
trust_delta: 0
next: END

소장님이 숫자로 장난을 치고 있다는 건 짐작하고 있었습니다. 하지만 제 업무는 시스템을 유지하는 것이지, 타인의 도덕성을 감시하는 게 아닙니다. 전 제 할 일을 완벽히 했습니다.

## NODE: ACCESS_MOD
type: FIXED
speaker: 최민석
emotion: annoyed
trust_delta: -3
next: END

…그건 보안 강화를 위한 정기적인 권한 업데이트였습니다. 사고와 시점이 겹친 건 우연일 뿐이죠. 제 행동을 범죄와 연결시키려는 노력이 가상하군요.

## NODE: END
type: END
speaker: 최민석
emotion: neutral
trust_delta: 0

더 확실한 증거를 가져오시죠. 이런 추측성 질문은 사양하겠습니다.