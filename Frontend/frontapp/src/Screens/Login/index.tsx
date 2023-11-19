import { Button, Card, CardBody, CardHeader, Divider, Input } from "@nextui-org/react"
import axios from "axios";
import { useEffect, useState } from "react";
import { useForm } from 'react-hook-form'
import { useNavigate } from "react-router-dom";
import { usePlantRiskStore } from '../../Store/plantsRisksStore.jsx';
import RecoverPasswordModal from '../../Components/RecoverPasswordModal/index.jsx'

function Login() {
  const { register, handleSubmit } = useForm();
  const [openRecoverPasswordModal, setOpenRecoverPasswordModal] = useState(false)
  const token = localStorage.getItem('token');
  const fetchPlantsRisks = usePlantRiskStore((state) => state.fetchPlantsRisks);
  const navigate = useNavigate();

  useEffect(() => {
    if(!token)
      return

    navigate("/")
  }, [token, navigate, fetchPlantsRisks])

  const login = (data) => {
    localStorage.setItem('token', data);
    navigate("/")
  }


  const onSubmit = (e) => {
    axios.post('https://localhost:44374/security', 
      {
        email: e.email,
        password: e.password
      })
      .then(res => login(res.data))
      .catch(err => console.log(err));
  }

  return (
    <div className="flex items-center justify-center h-screen bg-softwhite">
      <RecoverPasswordModal openModal={openRecoverPasswordModal} setOpenModal={setOpenRecoverPasswordModal} />
      <form className="w-full max-w-md" onSubmit={handleSubmit(onSubmit)}>
        <Card>
          <CardHeader className="flex items-center justify-center">
            <h1 className="text-2xl font-bold">Log In</h1>
          </CardHeader>
          <Divider />
          <CardBody>
            <div className="w-full flex flex-col items-center justify-center">
              <Input label="Email" className="p-2 text-2xl" {...register("email", { required: true })}/>
              <Input type="password" label="Password" className="p-2 text-2xl" {...register("password", { required: true })} />
              <Button type="submit" color="success" className="p-5 font-bold text-white">Sign In</Button>
            </div>
            <p onClick={() => setOpenRecoverPasswordModal(true)} className="text-softblue pt-5 hover:cursor-pointer">¿Forgot your password?</p>
          </CardBody>
        </Card>
      </form>
    </div>
  )
}

export default Login