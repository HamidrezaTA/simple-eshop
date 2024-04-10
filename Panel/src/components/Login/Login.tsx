import axios, { AxiosResponse } from "axios";
import { useState } from "react";

interface IConfirmOTPRequest {
  code: string;
  mobileNumber: string;
}

function Login() {
  const [status, setStatus] = useState("otp");
  const [mobileNumber, setMobileNumber] = useState("");
  const [otpCode, setOtpCode] = useState("");

  const handleMobileNumberChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setMobileNumber(event.target.value);
  };

  const handleOtpCodeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setOtpCode(event.target.value);
  };

  const onSendClick = () => {
    setStatus("confirm");
  };

  const onConfirmClick = () => {
    console.log("Confirm clicked ...");

    var confirmOTPDto: IConfirmOTPRequest = {
      code: otpCode,
      mobileNumber: mobileNumber,
    };

    axios
      .post<IConfirmOTPRequest, AxiosResponse<string>>(
        "http://localhost:5152/api/User/confirm-otp",
        confirmOTPDto
      )
      .then((response) => {
        console.log(response.data);
      })
      .catch((error) => {
        console.error("Error confirming OTP:", error);
      });
  };

  return (
    <>
      <div className="w3-display-topmiddle">
        <h2>Simple eShop Panel</h2>
      </div>
      <div
        className={
          status === "otp"
            ? "w3-display-middle w3-show"
            : "w3-display-middle w3-hide"
        }
      >
        <div className="w3-container">
          <label>Enter your mobile number</label>
          <input
            id="mobileNumberInput"
            className="w3-input"
            type="text"
            value={mobileNumber}
            onChange={handleMobileNumberChange}
          ></input>
          <button
            className="w3-button w3-black w3-margin-top"
            onClick={onSendClick}
          >
            Send
          </button>
        </div>
      </div>
      <div
        className={
          status === "confirm"
            ? "w3-display-middle w3-show"
            : "w3-display-middle w3-hide"
        }
      >
        <div className="w3-container">
          <label>Enter code</label>
          <input
            id="otpCodeInput"
            className="w3-input"
            type="text"
            value={otpCode}
            onChange={handleOtpCodeChange}
          ></input>
          <button
            className="w3-button w3-black w3-margin-top"
            onClick={onConfirmClick}
          >
            Confirm
          </button>
        </div>
      </div>
    </>
  );
}

export default Login;
