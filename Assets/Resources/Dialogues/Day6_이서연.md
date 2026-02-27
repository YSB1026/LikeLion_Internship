## NODE: START
type: CHOICE
speaker: 이서연
emotion: crying
trust_delta: 0

조사관님, 제가 결국 확인했어요. 사고 당일 제어실 모니터에 떠 있던 건 실험 수치가 아니었어요. 박 소장님이 실험실 안에서 비상 레버를 당기려고 애쓰는 CCTV 화면이었죠. 최민석 씨는 그걸… 그냥 보고만 있었던 거예요.

- [최민석 씨가 비상 레버 작동을 막았다는 증거가 있나요?] -> PROOF_BLOCK
- [박 소장님은 마지막까지 살려고 노력했군요.] -> PARK_LAST
- [이제 당신이 증언석에 서야 합니다. 할 수 있겠어요?] -> WITNESS

## NODE: PROOF_BLOCK
type: FIXED
speaker: 이서연
emotion: angry
trust_delta: 1
next: END

네, 비상 로그에 기록이 남아있었어요. 레버를 당길 때마다 '관리자 승인 거부' 메시지가 떴더라고요. 최민석 씨가 수동 제어권을 강제로 묶어버린 거죠. 이건 사고가 아니라 처형이었어요.

## NODE: PARK_LAST
type: FIXED
speaker: 이서연
emotion: crying
trust_delta: 0
next: PARK_AI

소장님이 조작을 한 건 잘못이지만, 그렇다고 이런 식으로 죽어야 했던 건 아니에요. 소장님은 마지막 순간에 서버실 쪽을 향해 손을 뻗고 있었대요. 최민석 씨가 자신을 구해줄 거라고 믿었을까요?

## NODE: PARK_AI
type: AI
speaker: 이서연
ai:role:npcweight:0.5
next: END

박 소장의 마지막 모습과 연구소의 비극적인 분위기를 묘사합니다. 이서연은 이제 최민석에 대한 공포를 분노로 바꾸어 플레이어에게 모든 증거를 넘깁니다.

## NODE: WITNESS
type: FIXED
speaker: 이서연
emotion: neutral
trust_delta: 2
next: END

할게요. 제가 본 모든 것, 제가 조작했던 데이터들까지 다 고백할게요. 저도 벌을 받겠죠… 하지만 저 괴물이 아무 일 없었다는 듯이 풀려나는 꼴은 못 봐요.

## NODE: END
type: END
speaker: 이서연
emotion: neutral
trust_delta: 0

더 이상 도망치지 않을게요. 진실을 밝혀주세요.