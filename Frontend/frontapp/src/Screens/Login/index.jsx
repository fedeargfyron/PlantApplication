import { Button, Card, CardBody, CardHeader, CircularProgress, Divider, Input } from "@nextui-org/react"
import { useEffect, useState } from "react";
import { useForm } from 'react-hook-form'
import { useNavigate } from "react-router-dom";
import { useUserStore } from '../../Store/usersStore.jsx';
import RecoverPasswordModal from '../../Components/RecoverPasswordModal/index.jsx'
import InformationModal from '../../Components/InformationModal/index.jsx'
import jwt_decode from "jwt-decode";

function Login() {
  const { 
    register, 
    handleSubmit, 
    formState: { errors }
  } = useForm();
  const [openRecoverPasswordModal, setOpenRecoverPasswordModal] = useState(false)
  const [open, setOpen] = useState(false);
  const token = localStorage.getItem('token');
  const { 
    loginToken,
    loginIsLoading,
    loginIsError, 
    login
  } = useUserStore((state) => state);
  const navigate = useNavigate();

  useEffect(() => {
    if(loginIsLoading || loginIsError)
      setOpen(true)
    
  }, [loginIsLoading, loginIsError])

  useEffect(() => {
    if(!token)
      return
    
    navigate("/")
  }, [token, navigate])

  useEffect(() => {
    if(!loginToken)
      return;

      localStorage.setItem('token', loginToken);
      localStorage.setItem('permissions', JSON.stringify(jwt_decode(loginToken)));
      navigate("/")
  }, [loginToken, navigate])
  
  const onSubmit = (e) => {
    const data = {
      email: e.email,
      password: e.password
    }
    login(data);
  }

  return (
    <div className="flex items-center justify-center min-h-screen bg-softwhite">
      <InformationModal open={open} setOpen={setOpen} title='Log In'>
        {loginIsLoading && <CircularProgress />}
        {loginIsError && <p>Error!</p>}
      </InformationModal>
      <RecoverPasswordModal openModal={openRecoverPasswordModal} setOpenModal={setOpenRecoverPasswordModal} />
      <form className="w-full max-w-md" onSubmit={handleSubmit(onSubmit)}>
        <Card>
          <CardHeader className="flex items-center justify-center">
            <h1 className="text-2xl font-bold">Log In</h1>
          </CardHeader>
          <Divider />
          <CardBody>
            <div className="w-full flex flex-col">
              <Input label="Email" color={errors.email ? 'danger' : ''} className="pb-2 text-2xl" {...register("email", { required: "Required" })}/>
              <Input type="password" color={errors.password ? 'danger' : ''} label="Password" className="pt-2 pb-2 text-2xl" {...register("password", { required: "Required" })} />
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